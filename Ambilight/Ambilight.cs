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

        int red, green, blue, counter;

        public Ambilight()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            port.Open();

            while(true)
            {
                Bitmap bmpScreenshot = Screenshot();
                String infoToSend = "";

                for (int i = 0; i < 30; i++)
                {
                    Color sendColor = findMeanColor(i, bmpScreenshot);
                    infoToSend += intToHex(sendColor.R) + intToHex(sendColor.G) + intToHex(sendColor.B); //+ "/";
                    //Debug.WriteLine(i + " = "); //+ intToHex(i));
                    //Debug.WriteLine("Red: " + sendColor.R + " = " + intToHex(sendColor.R));
                    //Debug.WriteLine("Blue: " + sendColor.B + " = " + intToHex(sendColor.B));
                    //Debug.WriteLine("Green: " + sendColor.G + " = " + intToHex(sendColor.G));

                    //sendOverPort(infoToSend);
                    //System.Threading.Thread.Sleep(5);
                }
                
                infoToSend += "/";
                sendOverPort(infoToSend);

                //Debug.WriteLine("Send: " + infoToSend);

                System.Threading.Thread.Sleep(5);
            }
        }

        private Bitmap Screenshot()
        {
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

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
                for (int j = 0; j < Screen.PrimaryScreen.Bounds.Height / 3; j+=5)
                {
                    getColor = fromBmp.GetPixel(i + forLed * (Screen.PrimaryScreen.Bounds.Width / 30), j + Screen.PrimaryScreen.Bounds.Height / 10);

                    red += getColor.R;
                    green += getColor.G;
                    blue += getColor.B;

                    counter++;
                }
            }

            counter = counter;

            red = red / counter;
            green = green / counter;
            blue = blue / counter;

            return Color.FromArgb(red, green, blue);
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
    }
}
