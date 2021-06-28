using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Simulacion
{
    public partial class Simulation : Form
    {
        List<Square> sl1;
        List<Square> sl2;
        List<Square> sl3;
        int i = 0;
        System.Windows.Forms.Timer t;
        int x = 0;
        Random rdm = new Random();

        public Simulation()
        {
            InitializeComponent();

            t = new System.Windows.Forms.Timer();
            t.Tick += T_Tick;
            t.Interval = 50;
            t.Start();
            sl1 = new List<Square>();
            sl2 = new List<Square>();
            sl3 = new List<Square>();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            foreach (Square s in sl1)
            {
                if (!s.move(this.Width, this.Height))
                {
                    s.setSentido(this.Width, this.Height);
                }
            }

            foreach (Square s in sl2)
            {
                if (!s.move(this.Width, this.Height))
                {
                    s.setSentido(this.Width, this.Height);
                }
            }

            foreach (Square s in sl3)
            {
                if (!s.move(this.Width, this.Height))
                {
                    s.setSentido(this.Width, this.Height);
                }
            }

            Invalidate();
        }

        public void hilo1()
        {
            for (i = 0; i < 10; i++)
            {
                Square s = new Square(rdm.Next(0, this.Width), rdm.Next(0, this.Height), sl1.Count);
                sl1.Add(s);
                Thread.Sleep(100);
            }
            MessageBox.Show("Thread 1 completed its work");
        }

        public void hilo2() 
        {
            for (i = 0; i < 10; i++) 
            {
                Square s = new Square(rdm.Next(0, this.Width), rdm.Next(0, this.Height), sl2.Count);
                sl2.Add(s);
                Thread.Sleep(100);
            }
            MessageBox.Show("Thread 2 completed its work");
        }

        public void hilo3()
        {
            for (i = 0; i < 10; i++)
            {
                Square s = new Square(rdm.Next(0, this.Width), rdm.Next(0, this.Height), sl3.Count);
                sl3.Add(s);
                Thread.Sleep(100);
            }
            MessageBox.Show("Thread 3 completed its work");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread h1 = new Thread(hilo1);
            h1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread h2 = new Thread(hilo2);
            h2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread h3 = new Thread(hilo3);
            h3.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Brush redBrush = new SolidBrush(Color.FromArgb(125, 205, 150, 100));
            Pen redPen = new Pen(redBrush, 8);
            Brush blueBrush = new SolidBrush(Color.FromArgb(125, 150, 40, 205));
            Pen bluePen = new Pen(blueBrush, 8);
            Brush greenBrush = new SolidBrush(Color.FromArgb(125, 0, 255, 0));
            Pen greenPen = new Pen(greenBrush, 8);

            for (int j = 0; j < sl1.Count(); j++)
            {
                g.DrawRectangle(redPen, sl1[j].getX(), sl1[j].getY(), 20, 20);
            }

            for (int k = 0; k < sl2.Count(); k++)
            {
                g.DrawRectangle(bluePen, sl2[k].getX(), sl2[k].getY(), 20, 20);
            }

            for (int l = 0; l < sl3.Count(); l++)
            {
                g.DrawRectangle(greenPen, sl3[l].getX(), sl3[l].getY(), 20, 20);
            }
        }
    }
}
