﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        Random random;
        double th1;
        double th2;
        double p1;
        double p2;
        double k;
        bool flag = true;

        public Form1()
        {
            AutoScrollMinSize = new Size(ClientRectangle.Width, ClientRectangle.Height);
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            pen = new Pen(Color.Blue);
            random = new Random();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            th1 = random.Next(0, 360) * Math.PI / 180;
            th2 = random.Next(-360, 0) * Math.PI / 180;
            p1 = random.NextDouble();
            random = new Random(random.Next());
            p2 = random.NextDouble();
            random = new Random(random.Next());
            k = random.Next(0, 100) / 10;
            read2();


            if (graphics == null) graphics = CreateGraphics();
            else graphics.Clear(BackColor);
            DrawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            read1();
            read2();
            if (!flag)//输入不合理，直接退出
            {
                flag = true;
                return;
            }

            if (graphics == null) graphics = this.CreateGraphics();
            else graphics.Clear(BackColor);
            DrawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        
        private void DrawCayleyTree(int n, double x0, double y0, double len, double th)
        {
            if (n == 0) return;//循环结束标志
            double x1 = x0 + len * Math.Cos(th);
            double y1 = y0 + len * Math.Sin(th);
            double x2 = x0 + k * len * Math.Cos(th);
            double y2 = y0 + k * len * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            DrawCayleyTree(n - 1, x1, y1, p1 * len, th + th1);//右支
            DrawCayleyTree(n - 1, x2, y2, p2 * len, th - th2);//左支
        }
       
        public void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void read1()
        {
            try
            {
                th1 = Convert.ToDouble(textBox1.Text) * Math.PI / 180;
                th2 = Convert.ToDouble(textBox2.Text) * Math.PI / 180;

                if (Convert.ToDouble(textBox4.Text) <= 0)
                    throw new Exception("per1  不能为负!");
                else p1 = Convert.ToDouble(textBox4.Text);

                if (Convert.ToDouble(textBox5.Text) <= 0)
                    throw new Exception("per2 不能为负!");
                else p2 = Convert.ToDouble(textBox5.Text);

                if (Convert.ToDouble(textBox3.Text) <= 0)
                    throw new Exception("k 不能为负!");
                else k = Convert.ToDouble(textBox3.Text);
            }
            catch (Exception e)
            {
                flag = false;
                MessageBox.Show(e.Message);
            }
        }
       
        private void read2()
        {
            try
            {
                switch (comboBox1.Text)
                {
                    case "Blue":
                        pen.Color = Color.Blue;
                        break;
                    case "Black":
                        pen.Color = Color.Black;
                        break;
                    case "Yellow":
                        pen.Color = Color.Yellow;
                        break;
                    case "Red":
                        pen.Color = Color.Red;
                        break;
                    case "Brown":
                        pen.Color = Color.Brown;
                        break;
                }
                switch (comboBox2.Text)
                {
                    case "1":
                        pen.Width = 1;
                        break;
                    case "2":
                        pen.Width = 2;
                        break;
                    case "3":
                        pen.Width = 3;
                        break;
                    case "4":
                        pen.Width = 4;
                        break;
                    case "5":
                        pen.Width = 5;
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }
    }
}

