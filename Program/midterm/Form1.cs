using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;



namespace midterm
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer wplayer_1 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer wplayer_2 = new WMPLib.WindowsMediaPlayer();
        Random r = new Random();
        int life, count, x, speed, hight, location;
        Boolean jump = false;
        PictureBox[] A;
        int[] B;



        private void Form1_Load(object sender, EventArgs e)
        {
            A = new PictureBox[5] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            B = new int[3] { 0, 0, 0 };
            location = pictureBox1.Top;
            hight = 0;
            life = 10;
            count = 0;
            speed = 10;
            DoubleBuffered = true;
            wplayer_1.URL = "說明.mp3";
            wplayer_1.settings.playCount = 100;
            pictureBox1.Image = pictureBox8.Image;
            pictureBox1.Left = 250;
            pictureBox1.Top = 550;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;

        }
       

        private void label6_Click(object sender, EventArgs e)
        {
            replay();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            play(count);
            obstacle(speed);
            jumping(jump);
        }
        private void obstacle(int speed)
        {
            if (pictureBox2.Top >= 850) { x = r.Next(20, 450); pictureBox2.Location = new Point(x, 0); } else { pictureBox2.Top += speed + r.Next(0, 10); }
            if (pictureBox3.Top >= 850) { x = r.Next(20, 450); pictureBox3.Location = new Point(x, 0); } else { pictureBox3.Top += speed + r.Next(0, 20); }
            if (pictureBox4.Top >= 850) { x = r.Next(20, 450); pictureBox4.Location = new Point(x, 0); } else { pictureBox4.Top += speed + r.Next(0, 20); }

        }
     
        public Form1()
        {
            InitializeComponent();
        }
        private void replay() {
            timer1.Start();
            pictureBox1.Image = pictureBox8.Image;
            pictureBox1.Left = 250;
            pictureBox1.Top = 550;
            pictureBox2.Top = 10;
            pictureBox3.Top = 10;
            pictureBox4.Top = 10;
            wplayer_2.URL = "遊戲.mp3";
            wplayer_2.settings.playCount = 100;

            DoubleBuffered = true;
            label1.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;

            location = pictureBox1.Top;
            hight = 0;
            life = 7;
            count = 0;
            speed = 10;
            A = new PictureBox[5] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            B = new int[3] { 0, 0, 0 };
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            wplayer_1.controls.stop();
            timer1.Start();
            wplayer_2.URL = "遊戲.mp3";
            wplayer_2.settings.playCount = 100;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label10.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox12.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { if (pictureBox1.Left >= 5) pictureBox1.Left += -15; }
            if (e.KeyCode == Keys.Right) { if (pictureBox1.Left < 480) pictureBox1.Left += 15; }
            if (e.KeyCode == Keys.Space) { jump = true; hight = -25; }

        }
        private void jumping(Boolean jump) {
            if (jump) { 
                pictureBox1.Top += hight; hight += 7;
                if (pictureBox1.Top >= location)
                {
                     pictureBox1.Top = location;
                       hight = 0;
                
                }
            }
           
        }
        private void gameover(int i) {
            if (life == 0)
            {
                label6.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                wplayer_2.controls.stop();
                timer1.Stop();
            }
            else
            {
                life -= 1;
                x = r.Next(10, 480); A[i].Location = new Point(x, 0);
            }
        }
        private void scoring(int count,int i) {
            B[count] += 1;
            x = r.Next(10, 480); A[i].Location = new Point(x, 0);
        }
        private void play(int count)
        {
            label2.Text = "Life: " + life;
            label3.Text = "Level-1: " + B[0];
            label4.Text = "Level-2: " + B[1];
            label5.Text = "Level-3: " + B[2];
      
            if (B[0] == 10)//完成階段一
            {
                count = 1;
                label3.Text = "Level-1: PASS ";
                pictureBox1.Image = pictureBox7.Image;
                if (B[1] == 20)//完成階段二
                {
                    count = 2;
                    label4.Text = "Level-2: PASS ";
                    pictureBox1.Image = pictureBox9.Image;
                    if (B[2] == 30)//完成階段三
                    {
                        count = 3;
                        label5.Text = "Level-3: PASS ";
                        label1.Visible = true;
                        label6.Visible = true;
                        label9.Visible = true;
                        wplayer_2.controls.stop();
                        timer1.Stop();
                    }
                }
            }
            
            
            if (count == 0)//階段一的處理
            {
                for (int i = 0; i < 5; i++)
                {
                    if (pictureBox1.Bounds.IntersectsWith(A[i].Bounds))
                    {
                        if (i != 0)
                        {
                            gameover(i);
                        }
                        else
                        {
                            scoring(count, i);
                        }
                    }
                }
            }
            else if (count == 1)//階段二的處理
            {
                pictureBox5.Visible = true;
                pictureBox10.Visible = true;
                if (pictureBox5.Top >= 850) { x = r.Next(20, 450); pictureBox5.Location = new Point(x, 0); } else { pictureBox5.Top += speed + r.Next(0, 10); }
                if (pictureBox10.Left >= 700) { pictureBox10.Left = 10; } else { pictureBox10.Left += speed + r.Next(0, 5); }
                if (pictureBox1.Bounds.IntersectsWith(pictureBox10.Bounds))
                {
                    if (life == 0)
                    {
                        label6.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        wplayer_2.controls.stop();
                        timer1.Stop();
                    }
                    else
                    {
                        life -= 1;
                        pictureBox10.Left = 10;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (pictureBox1.Bounds.IntersectsWith(A[i].Bounds))
                    {
                        if (i != 1)
                        {
                            gameover(i);
                        }
                        else
                        {
                            scoring(count, i);
                        }

                    }
                }
            }
            else if (count == 2)//階段三的處理
            {
                pictureBox6.Visible = true;
                pictureBox11.Visible = true;
                if (pictureBox5.Top >= 850) { x = r.Next(20, 450); pictureBox5.Location = new Point(x, 0); } else { pictureBox5.Top += speed + r.Next(0, 10); }
                if (pictureBox6.Top >= 850) { x = r.Next(20, 450); pictureBox6.Location = new Point(x, 0); } else { pictureBox6.Top += speed + r.Next(0, 10); }
                if (pictureBox10.Left >= 700) { pictureBox10.Left = 10; } else { pictureBox10.Left += speed + r.Next(0, 5); }
                if (pictureBox11.Left < 0) { pictureBox11.Left = 700; } else { pictureBox11.Left -= speed + r.Next(0, 5); }
                if (pictureBox1.Bounds.IntersectsWith(pictureBox10.Bounds))
                {
                    if (life == 0)
                    {
                        label6.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        wplayer_2.controls.stop();
                        timer1.Stop();
                    }
                    else
                    {
                        life -= 1;
                        pictureBox10.Left = -10;
                    }
                }
                if (pictureBox1.Bounds.IntersectsWith(pictureBox11.Bounds))
                {
                    if (life == 0)
                    {
                        label6.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        wplayer_2.controls.stop();
                        timer1.Stop();
                    }
                    else
                    {
                        life -= 1;
                        pictureBox11.Left = 800;
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    if (pictureBox1.Bounds.IntersectsWith(A[i].Bounds))
                    {
                        if (i != 2)
                        {
                            gameover(i);
                        }
                        else
                        {
                            scoring(count, i);
                        }
                    }
                }
            }
        }
    }
}
