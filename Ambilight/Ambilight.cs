using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace Ambilight
{
    public partial class Ambilight : Form
    {
        SerialPort port = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        bool running = false;
        bool showingArea = false;

        //Clock for debugging
        DateTime lastTime = DateTime.Now;
        DateTime currentTime = DateTime.Now;
        int loop = 0;

        int red, green, blue, counter; //This if for calculating the average color.

        byte[] infoToSend = new byte[200];
        int placeAt = 0;

        static int NUM_LEDS = 18;
        int BRIGHTNESS = 100;
        int CAPTURE_X = 10;
        int CAPTURE_Y = 10;
        int JUMP_X = 5;
        int JUMP_Y = 5;
        int OFFSET_HEIGHT = 0;
        int CAPTURE_HEIGHT = 5; //Portion of the screen to capture.
        int LIGHT_WIDTH = Screen.PrimaryScreen.Bounds.Width / NUM_LEDS;
        int LIGHT_HEIGHT = Screen.PrimaryScreen.Bounds.Height / 5; //Set 5 as standard.
        
        CaptureArea captArea = new CaptureArea();

        public Ambilight()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            port.Open();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                backgroundWorker1.RunWorkerAsync();
                running = true;
                buttonStartStop.Text = "Stop";
            }
            else
            {
                backgroundWorker1.CancelAsync();
                running = false;
                buttonStartStop.Text = "Start";
            }

        }
        
        private void textBoxOffset_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOffset.Text != "")
            {
                if (int.Parse(textBoxOffset.Text) >= 0 && int.Parse(textBoxOffset.Text) + LIGHT_HEIGHT < Screen.PrimaryScreen.Bounds.Height)
                {
                    OFFSET_HEIGHT = int.Parse(textBoxOffset.Text);
                    captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
                }
                else
                {
                    MessageBox.Show("Would go out of bounds.");
                    textBoxOffset.Text = OFFSET_HEIGHT.ToString();
                }
            }
        }

        private void buttonOffsetPlus_Click(object sender, EventArgs e)
        {
            if (OFFSET_HEIGHT + LIGHT_HEIGHT < Screen.PrimaryScreen.Bounds.Height)
            {
                OFFSET_HEIGHT++;
                textBoxOffset.Text = OFFSET_HEIGHT.ToString();
                labelTopOffset.Text = "Offset: " + OFFSET_HEIGHT + "px";
                captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
            }
            else
                MessageBox.Show("Would go out of bounds.");
        }

        private void buttonOffsetMinus_Click(object sender, EventArgs e)
        {
            if (OFFSET_HEIGHT > 0)
            {
                OFFSET_HEIGHT--;
                textBoxOffset.Text = OFFSET_HEIGHT.ToString();
                labelTopOffset.Text = "Offset: " + OFFSET_HEIGHT + "px";
                captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
            }
        }

        private void buttonHeightPlus_Click(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Height / (CAPTURE_HEIGHT + 1) + CAPTURE_Y < Screen.PrimaryScreen.Bounds.Height)
            {
                CAPTURE_HEIGHT++;
                labelCaptureHeight.Text = "Height: 1/" + CAPTURE_HEIGHT;
                captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
            }
            else
                MessageBox.Show("Would go out of bounds.");
        }

        private void buttonHeightMinus_Click(object sender, EventArgs e)
        {
            if ((Screen.PrimaryScreen.Bounds.Height / (CAPTURE_HEIGHT - 1)) + OFFSET_HEIGHT < Screen.PrimaryScreen.Bounds.Height)
            {
                CAPTURE_HEIGHT--;
                labelCaptureHeight.Text = "Height: 1/" + CAPTURE_HEIGHT;
                captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
            }
            else
                MessageBox.Show("Would go out of bounds.");
        }

        private void buttonCaptureXPlus_Click(object sender, EventArgs e)
        {
            if (CAPTURE_X < LIGHT_WIDTH)
            {
                CAPTURE_X++;
                labelCaptureX.Text = "Capture X: " + CAPTURE_X;
            }
            else
                MessageBox.Show("Would go out of bounds.");
        }

        private void buttonCaptureXMinus_Click(object sender, EventArgs e)
        {
            if (CAPTURE_X > 1)
            {
                CAPTURE_X--;
                labelCaptureX.Text = "Capture X: " + CAPTURE_X;
            }
            else
                MessageBox.Show("Can't gather less than 1 pixel.");
        }

        private void buttonCaptureYPlus_Click(object sender, EventArgs e)
        {
            if (CAPTURE_Y < LIGHT_HEIGHT)
            {
                CAPTURE_Y++;
                labelCaptureY.Text = "Capture Y: " + CAPTURE_Y;
            }
            else
                MessageBox.Show("Would go out of bounds.");
        }

        private void buttonCaptureYMinus_Click(object sender, EventArgs e)
        {
            if (CAPTURE_Y > 1)
            {
                CAPTURE_Y--;
                labelCaptureY.Text = "Capture Y: " + CAPTURE_Y;
            }
            else
                MessageBox.Show("Can't gather less than 1 pixel.");
        }

        private void buttonBrightnessPlus_Click(object sender, EventArgs e)
        {
            if (BRIGHTNESS <= 90)
            {
                BRIGHTNESS += 10;
                labelBrightness.Text = "Brightness: " + BRIGHTNESS.ToString();
            }
            else
                MessageBox.Show("Can't be brighter than 100%");
        }

        private void buttonBrightnessMinus_Click(object sender, EventArgs e)
        {
            if (BRIGHTNESS > 0)
            {
                BRIGHTNESS -= 10;
                labelBrightness.Text = "Brightness: " + BRIGHTNESS.ToString();
            }
            else
                MessageBox.Show("Can't less than 0%");
        }

        private void buttonAutoOffset_Click(object sender, EventArgs e)
        {
            if (showingArea)
                captArea.Hide();
            
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            Size s = this.Size;
            s.Width = Screen.PrimaryScreen.Bounds.Width;
            s.Height = Screen.PrimaryScreen.Bounds.Height;

            g.CopyFromScreen(0, 0, 0, 0, s);

            float amountOfDarkness = 1.0f;

            OFFSET_HEIGHT = 0;

            do
            {
                Color getColor = new Color();
                red = 0;
                green = 0;
                blue = 0;
                int blackCount = 0;

                for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i += 10)
                {
                    getColor = bmpScreenshot.GetPixel(i, OFFSET_HEIGHT);

                    //If all values are under 100 count as black pixel
                    if (getColor.R < 10 && getColor.G < 10 && getColor.B < 10)
                        blackCount++;
                }

                //If the whole row has more than half "black" pixels of those checked the loop will exit
                amountOfDarkness = blackCount / (Screen.PrimaryScreen.Bounds.Width / 10.0f);
                if (amountOfDarkness > 0.7)
                {
                    OFFSET_HEIGHT++;
                    textBoxOffset.Text = OFFSET_HEIGHT.ToString();
                    labelTopOffset.Text = "Offset: " + OFFSET_HEIGHT + "px";
                    captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
                }
            } while (amountOfDarkness > 0.7 && OFFSET_HEIGHT + LIGHT_HEIGHT < Screen.PrimaryScreen.Bounds.Height);

            textBoxOffset.Text = OFFSET_HEIGHT.ToString();
            if (showingArea)
                captArea.Show();
        }

        private void buttonShowCaptureArea_Click(object sender, EventArgs e)
        {
            if (!showingArea)
            {
                captArea.BackColor = Color.Black;
                captArea.FormBorderStyle = FormBorderStyle.None;
                captArea.Bounds = new Rectangle(0, OFFSET_HEIGHT, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT);
                captArea.TopMost = true;
                Application.EnableVisualStyles();
                captArea.Show();
                showingArea = true;
            }
            else
            {
                captArea.Hide();
                showingArea = false;
            }
        }

        private Bitmap Screenshot()
        {
            LIGHT_HEIGHT = Screen.PrimaryScreen.Bounds.Height / CAPTURE_HEIGHT; //To update the capture portion.

            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, LIGHT_HEIGHT);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            Size s = this.Size;
            s.Width = Screen.PrimaryScreen.Bounds.Width;
            s.Height = LIGHT_HEIGHT;

            g.CopyFromScreen(0, OFFSET_HEIGHT, 0, 0, s);

            return bmpScreenshot;
        }

        private Color findMeanColor(int forLed, Bitmap fromBmp)
        {
            Color getColor = new Color();
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            JUMP_X = LIGHT_WIDTH / CAPTURE_X;
            JUMP_Y = LIGHT_HEIGHT / CAPTURE_Y;

            for (int i = 0; i < LIGHT_WIDTH; i += JUMP_X)
            {
                for (int j = 0; j < LIGHT_HEIGHT; j += JUMP_Y)
                {
                    getColor = fromBmp.GetPixel(i + forLed * LIGHT_WIDTH, j);

                    red += getColor.R;
                    green += getColor.G;
                    blue += getColor.B;

                    counter++;
                }
            }

            return Color.FromArgb(red / counter, green / counter, blue / counter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Bitmap bmpScreenshot= Screenshot();
                    infoToSend[placeAt++] = Convert.ToByte('a');

                    //currentTime = DateTime.Now;
                    if ((DateTime.Now - lastTime).Seconds > 1)
                    {
                        lastTime = DateTime.Now;//DateTime.Now;
                        labelFramerate.Text = "Framerate: " + loop.ToString();
                        loop = 0;
                    }

                    for (int i = 0; i < NUM_LEDS; i++)
                    {
                        Color sendColor = findMeanColor(i, bmpScreenshot);
                        infoToSend[placeAt++] = Convert.ToByte(sendColor.R * BRIGHTNESS / 100);
                        infoToSend[placeAt++] = Convert.ToByte(sendColor.G * BRIGHTNESS / 100);
                        infoToSend[placeAt++] = Convert.ToByte(sendColor.B * BRIGHTNESS / 100);
                    }

                    loop++;
                    placeAt = 0;
                    port.Write(infoToSend, 0, (NUM_LEDS * 3 + 1));
                    //for (int i = 0; i < 91; i++)
                    //{
                    //    Debug.Write(infoToSend[i]);
                    //}
                    //Debug.WriteLine("");

                    //Dispose garbage to prevent "momory leakage"
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                }
            }
        }
    }
}
