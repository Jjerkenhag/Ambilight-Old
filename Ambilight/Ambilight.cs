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
        SerialPort port = new SerialPort("COM3", 19200, Parity.None, 8, StopBits.One);

        bool running = false;

        //Clock for debugging
        int timeSinceLast = 0;
        DateTime lastTime = DateTime.Now;
        DateTime currentTime = DateTime.Now;

        int red, green, blue, counter;

        public Ambilight()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            port.Open();
            button2.IsAccessible = false;

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            running = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            running = false;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private Bitmap Screenshot()
        {
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 3);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            Size s = this.Size;
            s.Height = Screen.PrimaryScreen.Bounds.Height / 3;
            s.Width = Screen.PrimaryScreen.Bounds.Width;

            g.CopyFromScreen(0, 0, 0, 0, s);

            return bmpScreenshot;
        }

        private Color findMeanColor(int forLed, Bitmap fromBmp)
        {
            Color getColor = new Color();
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            for (int i = 0; i < (Screen.PrimaryScreen.Bounds.Width / 30); i+=5)
            {
                for (int j = 0; j < Screen.PrimaryScreen.Bounds.Height / 3; j+=3)
                {
                    getColor = fromBmp.GetPixel(i + forLed * (Screen.PrimaryScreen.Bounds.Width / 30), j);

                    int toDiv = (int)Math.Log(Convert.ToDouble(j), 100) + 1;

                    red += (getColor.R / toDiv);
                    green += (getColor.G / toDiv);
                    blue += (getColor.B / toDiv);

                    counter++;
                }
            }

            return Color.FromArgb(red / counter, green / counter, blue / counter);
        }

        private String intToHex(int number)
        {
            string toReturn = "";
            
            toReturn = toReturn + oneHex(number / 16);
            toReturn = toReturn + oneHex(number % 16);

            return toReturn;
        }

        private char oneHex(int number)
        {
            char temp = '0';

            switch (number)
            {
                case 0:
                    temp = '0';
                    break;
                case 1:
                    temp = '1';
                    break;
                case 2:
                    temp = '2';
                    break;
                case 3:
                    temp = '3';
                    break;
                case 4:
                    temp = '4';
                    break;
                case 5:
                    temp = '5';
                    break;
                case 6:
                    temp = '6';
                    break;
                case 7:
                    temp = '7';
                    break;
                case 8:
                    temp = '8';
                    break;
                case 9:
                    temp = '9';
                    break;
                case 10:
                    temp = 'A';
                    break;
                case 11:
                    temp = 'B';
                    break;
                case 12:
                    temp = 'C';
                    break;
                case 13:
                    temp = 'D';
                    break;
                case 14:
                    temp = 'E';
                    break;
                case 15:
                    temp = 'F';
                    break;
                default:
                    break;
            }

            return temp;
        }

        private void sendOverPort(String infoToSend)
        {            
            port.Write(infoToSend);
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
                    Bitmap bmpScreenshot = Screenshot();
                    String infoToSend = "";

                    currentTime = DateTime.Now;
                    TimeSpan span = currentTime - lastTime;
                    lastTime = DateTime.Now;

                    if (span.Milliseconds < 120)
                    {
                        System.Threading.Thread.Sleep(120 - span.Milliseconds);
                    }

                    label1.Text = span.Milliseconds.ToString();

                    for (int i = 0; i < 30; i++)
                    {
                        Color sendColor = findMeanColor(i, bmpScreenshot);
                        infoToSend += intToHex(sendColor.R) + intToHex(sendColor.G) + intToHex(sendColor.B);
                        //Debug.WriteLine(i + " = "); //+ intToHex(i));
                        //Debug.WriteLine("Red: " + sendColor.R + " = " + intToHex(sendColor.R));
                        //Debug.WriteLine("Blue: " + sendColor.B + " = " + intToHex(sendColor.B));
                        //Debug.WriteLine("Green: " + sendColor.G + " = " + intToHex(sendColor.G));

                        //sendOverPort(infoToSend);
                        //System.Threading.Thread.Sleep(5);
                    }

                    infoToSend += "/";
                    sendOverPort(infoToSend);
                    
                    //Dispose garbage to prevent "momory leakage"
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();

                    //System.Threading.Thread.Sleep(5);
                }
            }
        }
    }
}
