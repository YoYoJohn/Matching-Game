using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s1041410_HW5
{
    public partial class Form1 : Form
    {        
        Rectangle[] rec = new Rectangle[16];       
        Image[] img = new Image[8] {Properties.Resources.apple, Properties.Resources.tomato,
        Properties.Resources.grape,Properties.Resources.cherry, Properties.Resources.orange,
        Properties.Resources.pineapple,Properties.Resources.watermelon,
        Properties.Resources.banana};
        Image img1 = Properties.Resources.P1;        
        int[] array = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] array1 = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int x = 50; int y = 50; int second = 0; int number = 0; Boolean T = false; int Second = 1; Boolean enable = true;
        int[] MousePoint = new int[2];
        Pen p1 = new Pen(Color.Black, 3);
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 16; i++)
            {
                rec[i] = new Rectangle(x, y, 100, 100);
                if (x == 350)
                {
                    x = 50;
                    y += 100;
                }
                else
                    x += 100;
            }  
        }

        Boolean judge(int a, int b)
        {
            if (array1[a] == array1[b])
                return true;
            else
                return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < 16; i++)
                e.Graphics.DrawRectangle(p1, rec[i]);
           
            for(int j=0;j<16;j++)
            {
                if(array1[j]==0)
                    e.Graphics.DrawImage(img1, rec[j]);
                else if (array1[j] == 1)
                    e.Graphics.DrawImage(img[0], rec[j]);
                else if (array1[j] == 2)
                    e.Graphics.DrawImage(img[1], rec[j]);
                else if (array1[j] == 3)
                    e.Graphics.DrawImage(img[2], rec[j]);
                else if (array1[j] == 4)
                    e.Graphics.DrawImage(img[3], rec[j]);
                else if (array1[j] == 5)
                    e.Graphics.DrawImage(img[4], rec[j]);
                else if (array1[j] == 6)
                    e.Graphics.DrawImage(img[5], rec[j]);
                else if (array1[j] == 7)
                    e.Graphics.DrawImage(img[6], rec[j]);
                else if (array1[j] == 8)
                    e.Graphics.DrawImage(img[7], rec[j]);

                e.Graphics.DrawRectangle(p1, rec[j]);
            }       
        }
       
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
             for (int i = 0; i < 16; i++)
                {
                    if (rec[i].Contains(e.Location) && array1[i] == 0&&enable==true)
                    {
                        array1[i] = array[i];
                        MousePoint[number] = i;
                        number++;
                    }
                }

                if (number == 2)
                {
                    number = 0;
                    T = judge(MousePoint[0], MousePoint[1]);
                    if (T == false)
                    {
                        this.Invalidate();
                        timer2.Start();
                        enable = false;
                    }
                }
                this.Invalidate();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.DoubleBuffered = true;
            for (int i = 0; i < 16; i++)
            {
                array[i] = random.Next(1,9);
                int count = 0;
                for (int j = 0; j < i; j++)
                {

                    if (array[i] == array[j])
                    {
                        count++;
                        if (count == 2)
                        {
                            i = i - 1;
                            break;
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            toolStripStatusLabel1.Text = second.ToString() + "  Seconds";
            for(int i=0;i<16;i++)
            {
                if (array1[i] == 0)
                    break;
                else
                    if (i == 15)
                        timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            Second++;
            if (Second == 2)
            {
                array1[MousePoint[0]] = 0;
                array1[MousePoint[1]] = 0;
                this.Invalidate();
                Second = 1;
                enable = true;
                timer2.Stop();            
            }          
        }

        private void reStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            toolStripStatusLabel1.Text = "0";
            timer1.Start();
            array = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {
                array[i] = random.Next(1, 9);
                int count = 0;
                for (int j = 0; j < i; j++)
                {

                    if (array[i] == array[j])
                    {
                        count++;
                        if (count == 2)
                        {
                            i = i - 1;
                            break;
                        }
                    }
                }
            }
            array1 = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            x = 0; y = 0; second = 0; number = 0; T = false; Second = 1; enable = true;     
            this.Invalidate();
        }
    }
}
