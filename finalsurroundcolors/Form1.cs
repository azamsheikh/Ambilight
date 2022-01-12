using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;


namespace finalsurroundcolors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            

            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
            int red = 0;
            int green = 0;
            int blue = 0;


            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {

                int y1value = 1000;
                for(int led = 0; led < 11; led++)
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

                        Color clr = bitmap.GetPixel(5, y1value);
                        red = clr.R;
                        green = clr.G;
                        blue = clr.B;

                        serialPort1.Write(led.ToString() + "#" + red.ToString("D3") + "," + green.ToString("D3") + "@" + blue.ToString("D3"));

                        

                    }

                    y1value -= 98;
                }



                int x1value = 5;
                for (int led2 = 11; led2 < 29; led2++)
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        Color clr = bitmap.GetPixel(x1value, 10);
                        red = clr.R;
                        green = clr.G;
                        blue = clr.B;
                        serialPort1.Write(led2.ToString() + "#" + red.ToString("D3") + "," + green.ToString("D3") + "@" + blue.ToString("D3"));
                    }


                    x1value += 106;

                }


                int y2value = 5;
                for (int led3 = 29; led3 < 40; led3++)
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);

                        Color clr = bitmap.GetPixel(1915, y2value);
                        red = clr.R;
                        green = clr.G;
                        blue = clr.B;

                        serialPort1.Write(led3.ToString() + "#" + red.ToString("D3") + "," + green.ToString("D3") + "@" + blue.ToString("D3"));



                    }

                    y2value += 98;
                }


                int x2value = 5;
                for (int led4 = 40; led4 < 59; led4++)
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        Color clr = bitmap.GetPixel(x2value, 1075);
                        red = clr.R;
                        green = clr.G;
                        blue = clr.B;
                        serialPort1.Write(led4.ToString() + "#" + red.ToString("D3") + "," + green.ToString("D3") + "@" + blue.ToString("D3"));
                    }


                    x1value += 106;

                }
















            }













        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = textBox1.Text;
            serialPort1.Open();
            timer1.Enabled = true;

        }
    }
}
