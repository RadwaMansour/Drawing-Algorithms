using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bresenham
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void pictureBox1_Paint(object sender, PaintEventArgs e) 
        {

        }
      

        private void Button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int x2 = int.Parse(textBox2.Text);
            int y1 = int.Parse(textBox3.Text);
            int y2 = int.Parse(textBox4.Text);
            lineBres(x1, y1, x2, y2);

        }



        /*  Bresenham line-drawing procedure for |m| < 1.0.  */
        void lineBres(int x0, int y0, int xEnd, int yEnd)
        {

            int x = x0;
            int y = y0;

            int dx = xEnd - x0;
            int dy = yEnd - y0;

            int delta_NE = 2 * (dy - dx);
            int delta_E = 2 * dy;
            int delta_W = 2 * (dx - dy);
            int delta_SE = 2 * dx;
            int d = (2 * dy) - dx;
            int d2 = (2 * dx) - dy;
            if (x0 > xEnd)
            {
                x = xEnd; y = yEnd; xEnd = x0;
            }
            else
            {
                x = x0; y = y0;
            }
            //m_image.put( x, y, m_color );
            var aBrush = Brushes.Black;
            var line = pictureBox1.CreateGraphics();
            
           
            // for (int i = 1; i < 150; i++)
            //{
            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y, 2, 2);
            if (dx > 0)
            { //1 & 4
                if (dy > 0)
                { //first quadrant
                    if (dx >= dy)
                    { //first octant

                        while (x < xEnd)
                        {
                            if (d >= 0) // NE
                            {
                                d += delta_NE;
                                x++; y++;
                            }
                            else // E
                            {
                                d += delta_E;
                                x++;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                    else
                    { //second octant
                        while (y < yEnd)
                        {
                            if (d2 >= 0) // W
                            {
                                d2 += delta_W;
                                y++; x++;
                            }
                            else // SE
                            {
                                d2 += delta_SE;
                                y++;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                }
                else
                { //fourth quadrant
                    if (dx >= -dy)
                    { //eigth octant
                        while (x < xEnd)
                        {
                            if (d >= 0) // NE
                            {
                                d += delta_NE;
                                x++; y--;
                            }
                            else // E
                            {
                                d -= delta_E;
                                x++;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                    else
                    { //seventh octant
                        while (y > yEnd)
                        {
                            if (d2 >= 0) // NE
                            {
                                d2 += delta_W;
                                y--; x++;
                            }
                            else // E
                            {
                                d2 -= delta_SE;
                                y--;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                }
            }
            else
            {
                if (dy >= 0)
                { //second quadrant
                    if (dx < -dy)
                    { //fourth octant
                        while (x > xEnd)
                        {
                            if (d >= 0) // NE
                            {
                                d += delta_E;
                                x--; y++;
                            }
                            else // E
                            {
                                d += delta_NE;
                                x--;
                            }
                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                    else
                    { //third octant
                        while (x > xEnd)
                        {
                            if (d >= 0) // NE
                            {
                                d -= delta_E;
                                x--; y++;
                            }
                            else // E
                            {
                                d += delta_E;
                                x--;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }
                }
                else
                { //third quadrant
                    if (dx > dy)
                    { //sixth octant
                        while (y > yEnd)
                        {
                            if (d2 >= 0) // NE
                            {
                                d2 -= delta_W;
                                x--; y--;
                            }
                            else // E
                            {
                                d2 -= delta_SE;
                                y--;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Width / 2) - y , 2, 2);
                        }
                    }
                    else
                    { //fifth octant
                        while (x > xEnd)
                        {
                            if (d >= 0) // NE
                            {
                                d -= delta_NE;
                                x--; y--;
                            }
                            else // E
                            {
                                d -= delta_E;
                                x--;
                            }

                            line.FillRectangle(aBrush, x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - y , 2, 2);
                        }
                    }

                }
            }

        }

          

        void lineDDA(int x0, int y0, int xEnd, int yEnd)
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)(dx) / (float)steps;
            yIncrement = (float)(dy) / (float)steps;
            var ddaBrush = Brushes.Black;
            var line1 = pictureBox1.CreateGraphics();
            // for (int i = 1; i < 150; i++)
            //{
            line1.FillRectangle(ddaBrush, (int)Math.Round(x)+(pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (int)Math.Round(y), 1, 1);
            //}
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                line1.FillRectangle(ddaBrush, (int)Math.Round(x) + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - (int)Math.Round(y), 2, 2);
            }
        }
        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            var ddaBrush = Brushes.Black;
            var line1 = pictureBox1.CreateGraphics();

            line1.FillRectangle(ddaBrush, xCenter + x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter + x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - y, 2, 2);
        }
        void DrawEllipse(int xCenter, int yCenter, int a, int b)
        {
            int a2 = a * a;
            int b2 = b * b;
            int twoa2 = 2 * a2;
            int twob2 = 2 * b2;
            int p;
            int x = 0;
            int y = b;
            int px = 0;
            int py = twoa2 * y;

            /* Plot the initial point in each quadrant. */
            ellipsePlotPoints(xCenter, yCenter, x, y);

            /* Region 1 */
            p = (int)Math.Round(b2 - (a2 * b) + (0.25 * a2));
            while (px < py)
            {
                x++;
                px += twob2;
                if (p < 0)
                    p += b2 + px;
                else
                {
                    y--;
                    py -= twoa2;
                    p += b2 + px - py;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }

            /* Region 2 */
            p = (int)Math.Round(b2 * (x + 0.5) * (x + 0.5) + a2 * (y - 1) * (y - 1) - a2 * b2);
            while (y > 0)
            {
                y--;
                py -= twoa2;
                if (p > 0)
                    p += a2 - py;
                else
                {
                    x++;
                    px += twob2;
                    p += a2 - py + px;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
        }
    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox5.Text);
            int x2 = int.Parse(textBox6.Text);
            int y1 = int.Parse(textBox7.Text);
            int y2 = int.Parse(textBox8.Text);
            lineDDA(x1, y1, x2, y2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        void CirclePoint(int xCenter, int yCenter, int x, int y)
        {
            var ddaBrush = Brushes.Black;
            var line1 = pictureBox1.CreateGraphics();

            line1.FillRectangle(ddaBrush, xCenter + x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter + x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - x + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - y, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter + y + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + x, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - y + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter + x, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter + y + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - x, 2, 2);
            line1.FillRectangle(ddaBrush, xCenter - y + (pictureBox1.Size.Width / 2), (pictureBox1.Size.Height / 2) - yCenter - x, 2, 2);

        }

        void Circle(int xCenter, int yCenter, int r)
        {
            int x = 0;
            int y = r;
            int p = 1 - r;
            CirclePoint(xCenter, yCenter, x, y);
            while(x<y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                CirclePoint(xCenter, yCenter, x, y);
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox9.Text);
            int y = int.Parse(textBox11.Text);
            int r = int.Parse(textBox10.Text);
            Circle(x, y, r);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int xCenter = int.Parse(textBox12.Text);
            int yCenter = int.Parse(textBox13.Text);
            int xRadius = int.Parse(textBox14.Text);
            int yRadius = int.Parse(textBox15.Text);
            DrawEllipse(xCenter, yCenter, xRadius, yRadius);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                int x1 = int.Parse(textBox16.Text);
                int x2 = int.Parse(textBox18.Text);
                int y1 = int.Parse(textBox17.Text);
                int y2 = int.Parse(textBox18.Text);
                int x3 = int.Parse(textBox20.Text);
                int x4 = int.Parse(textBox22.Text);
                int y3 = int.Parse(textBox21.Text);
                int y4 = int.Parse(textBox23.Text);
                lineDDA(x1, y1, x2, y2);
                lineDDA(x2, y2, x3, y3);
                lineDDA(x3, y3, x4, y4);
                lineDDA(x4, y4, x1, y1);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            int X =  int.Parse(textBox24.Text);
            int Y =  int.Parse(textBox25.Text);
            lineDDA(x1 + X, y1 + Y, x2 + X, y2 + Y);
            lineDDA(x2 + X, y2 + Y, x3 + X, y3 + Y);
            lineDDA(x3 + X, y3 + Y, x4 + X, y4 + Y);
            lineDDA(x4 + X, y4 + Y, x1 + X, y1 + Y);
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            int X = int.Parse(textBox24.Text);
            int Y = int.Parse(textBox25.Text);
            lineDDA(x1 * X, y1 * Y, x2 * X, y2 * Y);
            lineDDA(x2 * X, y2 * Y, x3 * X, y3 * Y);
            lineDDA(x3 * X, y3 * Y, x4 * X, y4 * Y);
            lineDDA(x4 * X, y4 * Y, x1 * X, y1 * Y);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            double angle = int.Parse(textBox26.Text);
            double sine = Math.Sin((angle * (Math.PI)) / 180);
            double cosine = Math.Cos((angle * (Math.PI)) / 180);
            lineDDA(Convert.ToInt32((x1 * cosine) - (y1 * sine)) , Convert.ToInt32((x1 * sine) + (y1 * cosine)), Convert.ToInt32((x2 * cosine) - (y2 * sine)), Convert.ToInt32((x2 * sine) + (y2 * cosine)));
            lineDDA(Convert.ToInt32((x2 * cosine) - (y2 * sine)), Convert.ToInt32((x2 * sine) + (y2 * cosine)), Convert.ToInt32((x3 * cosine) - (y3 * sine)), Convert.ToInt32((x3 * sine) + (y3 * cosine)));
            lineDDA(Convert.ToInt32((x3 * cosine) - (y3 * sine)), Convert.ToInt32((x3 * sine) + (y3 * cosine)), Convert.ToInt32((x4 * cosine) - (y4 * sine)), Convert.ToInt32((x4 * sine) + (y4 * cosine)));
            lineDDA(Convert.ToInt32((x4 * cosine) - (y4 * sine)), Convert.ToInt32((x4 * sine) + (y4 * cosine)), Convert.ToInt32((x1 * cosine) - (y1 * sine)), Convert.ToInt32((x1 * sine) + (y1 * cosine)));
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            int X = int.Parse(textBox27.Text);
            lineDDA(x1 + (X * y1), y1 , x2 + (X * y2), y2 );
            lineDDA(x2 + (X * y2), y2 , x3 + (X * y3), y3 );
            lineDDA(x3 + (X * y3), y3 , x4 + (X * y4), y4 );
            lineDDA(x4 + (X * y4), y4 , x1 + (X * y1), y1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            int Y = int.Parse(textBox28.Text);
            lineDDA(x1 , (Y * x1) + y1, x2 , (Y * x2) + y2);
            lineDDA(x2 , (Y * x2) + y2, x3 , (Y * x3) + y3);
            lineDDA(x3 , (Y * x3) + y3, x4 , (Y * x4) + y4);
            lineDDA(x4 , (Y * x4) + y4, x1 , (Y * x1) + y1);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            lineDDA((-1 * x1), y1, (-1 * x2), y2);
            lineDDA((-1 * x2), y2, (-1 * x3), y3);
            lineDDA((-1 * x3), y3, (-1 * x4), y4);
            lineDDA((-1 * x4), y4, (-1 * x1), y1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            lineDDA(x1, (-1 * y1), x2, (-1 * y2));
            lineDDA(x2, (-1 * y2), x3, (-1 * y3));
            lineDDA(x3, (-1 * y3), x4, (-1 * y4));
            lineDDA(x4, (-1 * y4), x1, (-1 * y1));

        }

        private void button14_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox16.Text);
            int x2 = int.Parse(textBox18.Text);
            int y1 = int.Parse(textBox17.Text);
            int y2 = int.Parse(textBox18.Text);
            int x3 = int.Parse(textBox20.Text);
            int x4 = int.Parse(textBox22.Text);
            int y3 = int.Parse(textBox21.Text);
            int y4 = int.Parse(textBox23.Text);
            lineDDA((-1 * x1), (-1 * y1), (-1 * x2), (-1 * y2));
            lineDDA((-1 * x2), (-1 * y2), (-1 * x3), (-1 * y3));
            lineDDA((-1 * x3), (-1 * y3), (-1 * x4), (-1 * y4));
            lineDDA((-1 * x4), (-1 * y4), (-1 * x1), (-1 * y1));
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);
            int X = int.Parse(textBox45.Text);
            int Y = int.Parse(textBox46.Text);
            int Z = int.Parse(textBox51.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1 + X);
            string Y1 = Convert.ToString(y1 + Y);
            string Z1 = Convert.ToString(z1 + Z);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2 + X);
            string Y2 = Convert.ToString(y2 + Y);
            string Z2 = Convert.ToString(z2 + Z);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3 + X);
            string Y3 = Convert.ToString(y3 + Y);
            string Z3 = Convert.ToString(z3 + Z);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4 + X);
            string Y4 = Convert.ToString(y4 + Y);
            string Z4 = Convert.ToString(z4 + Z);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);
            int X = int.Parse(textBox45.Text);
            int Y = int.Parse(textBox46.Text);
            int Z = int.Parse(textBox51.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1 * X);
            string Y1 = Convert.ToString(y1 * Y);
            string Z1 = Convert.ToString(z1 * Z);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2 * X);
            string Y2 = Convert.ToString(y2 * Y);
            string Z2 = Convert.ToString(z2 * Z);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3 * X);
            string Y3 = Convert.ToString(y3 * Y);
            string Z3 = Convert.ToString(z3 * Z);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4 * X);
            string Y4 = Convert.ToString(y4 * Y);
            string Z4 = Convert.ToString(z4 * Z);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);
            double angle = int.Parse(textBox47.Text);
            double sine = Math.Sin((angle * (Math.PI)) / 180);
            double cosine = Math.Cos((angle * (Math.PI)) / 180);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1);
            string Y1 = Convert.ToString((y1 * cosine) - (z1 * sine));
            string Z1 = Convert.ToString((y1 * sine) + (z1 * cosine));

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2);
            string Y2 = Convert.ToString((y2 * cosine) - (z2 * sine));
            string Z2 = Convert.ToString((y2 * sine) + (z2 * cosine));

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3);
            string Y3 = Convert.ToString((y3 * cosine) - (z3 * sine));
            string Z3 = Convert.ToString((y3 * sine) + (z3 * cosine));

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4);
            string Y4 = Convert.ToString((y4 * cosine) - (z4 * sine));
            string Z4 = Convert.ToString((y4 * sine) + (z4 * cosine));

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);
            double angle = int.Parse(textBox47.Text);
            double sine = Math.Sin((angle * (Math.PI)) / 180);
            double cosine = Math.Cos((angle * (Math.PI)) / 180);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString((z1 * sine) + (x1 * cosine));
            string Y1 = Convert.ToString(y1);
            string Z1 = Convert.ToString((y1 * cosine) - (x1 * sine));

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString((z2 * sine) + (x2 * cosine));
            string Y2 = Convert.ToString(y2);
            string Z2 = Convert.ToString((y2 * cosine) - (x2 * sine));

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString((z3 * sine) + (x3 * cosine));
            string Y3 = Convert.ToString(y3);
            string Z3 = Convert.ToString((y3 * cosine) - (x3 * sine));

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString((z4 * sine) + (x4 * cosine));
            string Y4 = Convert.ToString(y4);
            string Z4 = Convert.ToString((y4 * cosine) - (x4 * sine));

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);
            double angle = int.Parse(textBox47.Text);
            double sine = Math.Sin((angle * (Math.PI)) / 180);
            double cosine = Math.Cos((angle * (Math.PI)) / 180);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString((x1 * cosine) - (y1 * sine));
            string Y1 = Convert.ToString((x1 * sine) + (y1 * cosine));
            string Z1 = Convert.ToString(z1);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString((x2 * cosine) - (y2 * sine));
            string Y2 = Convert.ToString((x2 * sine) + (y2 * cosine));
            string Z2 = Convert.ToString(z2);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString((x3 * cosine) - (y3 * sine));
            string Y3 = Convert.ToString((x3 * sine) + (y3 * cosine));
            string Z3 = Convert.ToString(z3);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString((x4 * cosine) - (y4 * sine));
            string Y4 = Convert.ToString((x4 * sine) + (y4 * cosine));
            string Z4 = Convert.ToString(z4);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1);
            string Y1 = Convert.ToString(y1);
            string Z1 = Convert.ToString(z1 * -1);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2);
            string Y2 = Convert.ToString(y2);
            string Z2 = Convert.ToString(z2 * -1);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3);
            string Y3 = Convert.ToString(y3);
            string Z3 = Convert.ToString(z3 * -1);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4);
            string Y4 = Convert.ToString(y4);
            string Z4 = Convert.ToString(z4 * -1);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1);
            string Y1 = Convert.ToString(y1 * -1);
            string Z1 = Convert.ToString(z1);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2);
            string Y2 = Convert.ToString(y2 * -1);
            string Z2 = Convert.ToString(z2);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3);
            string Y3 = Convert.ToString(y3 * -1);
            string Z3 = Convert.ToString(z3);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4);
            string Y4 = Convert.ToString(y4 * -1);
            string Z4 = Convert.ToString(z4);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);
            int x2 = int.Parse(textBox32.Text);
            int y2 = int.Parse(textBox33.Text);
            int z2 = int.Parse(textBox34.Text);
            int x3 = int.Parse(textBox35.Text);
            int y3 = int.Parse(textBox36.Text);
            int z3 = int.Parse(textBox37.Text);
            int x4 = int.Parse(textBox38.Text);
            int y4 = int.Parse(textBox39.Text);
            int z4 = int.Parse(textBox40.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1 * -1);
            string Y1 = Convert.ToString(y1);
            string Z1 = Convert.ToString(z1);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            string X2 = Convert.ToString(x2 * -1);
            string Y2 = Convert.ToString(y2);
            string Z2 = Convert.ToString(z2);

            textBox42.Text += "(" + X2 + " , " + Y2 + " , " + Z2 + ")";

            string X3 = Convert.ToString(x3 * -1);
            string Y3 = Convert.ToString(y3);
            string Z3 = Convert.ToString(z3);

            textBox43.Text += "(" + X3 + " , " + Y3 + " , " + Z3 + ")";

            string X4 = Convert.ToString(x4 * -1);
            string Y4 = Convert.ToString(y4);
            string Z4 = Convert.ToString(z4);

            textBox44.Text += "(" + X4 + " , " + Y4 + " , " + Z4 + ")";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);

            int X = int.Parse(textBox48.Text);
            int Y = int.Parse(textBox49.Text);
            int Z = int.Parse(textBox50.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1);
            string Y1 = Convert.ToString(y1 + (Y * x1));
            string Z1 = Convert.ToString(z1 + (Z * x1));

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";

            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);

            int X = int.Parse(textBox48.Text);
            int Y = int.Parse(textBox49.Text);
            int Z = int.Parse(textBox50.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1 + (X * y1));
            string Y1 = Convert.ToString(y1);
            string Z1 = Convert.ToString(z1 + (Z * y1));

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox29.Text);
            int y1 = int.Parse(textBox30.Text);
            int z1 = int.Parse(textBox31.Text);

            int X = int.Parse(textBox48.Text);
            int Y = int.Parse(textBox49.Text);
            int Z = int.Parse(textBox50.Text);

            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();

            string X1 = Convert.ToString(x1 + (X * z1));
            string Y1 = Convert.ToString(y1 + (Y * z1));
            string Z1 = Convert.ToString(z1);

            textBox41.Text += "(" + X1 + " , " + Y1 + " , " + Z1 + ")";
        }
    }
}
