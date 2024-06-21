using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wind
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

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = panel1.CreateGraphics();
            g.Clear(Color.White);

            Point[] points = new Point[4];

            points[0] = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox5.Text));
            points[1] = new Point(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox6.Text));
            points[2] = new Point(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox7.Text));
            points[3] = new Point(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox8.Text));

            Pen pen = new Pen(Color.Black);

            g.DrawBezier(pen, points[0], points[1], points[2], points[3]);
        }
        private void SierpinskiCarpet(int order, int x, int y, int width, int height)
        {
            Graphics g;
            g = panel1.CreateGraphics();

            if (order == 0)
            {
                g.FillRectangle(Brushes.Black, x, y, width, height);
            }
            else
            {
                int newWidth = width / 3;
                int newHeight = height / 3;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != 1 || j != 1)
                        {
                            SierpinskiCarpet(order - 1, x + i * newWidth, y + j * newHeight, newWidth, newHeight);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = panel1.CreateGraphics();
            g.Clear(Color.White);

            int x, y, h, w, order;
            x = Convert.ToInt32(textBox9.Text);
            y = Convert.ToInt32(textBox10.Text);
            h = Convert.ToInt32(textBox11.Text);
            w = Convert.ToInt32(textBox12.Text);
            order = Convert.ToInt32(textBox13.Text);

            SierpinskiCarpet(order,x,y,w,h);
        }
    }
}
