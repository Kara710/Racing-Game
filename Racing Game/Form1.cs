using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Racing_Game
{
    public partial class Form1 : Form
    {
        int playerspeed = 5;
        int scorecoins = 0;

        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        //If ball hits the obstacle is Gameover
        private void Gameover()
        {

            if (obj1.Bounds.IntersectsWith(obstacle.Bounds))
            {
                timer1.Enabled = false;
                panel1.Visible = true;
                label4.Text = Convert.ToString(scorecoins);
                scorecoins = 0;

            }

        }

        //If ball hits a coin then score adds +10
        private void CoinsAdd()
        {
            Random rnd = new Random();
            int x;
            if (obj1.Bounds.IntersectsWith(coin1.Bounds))
            {
                
                scorecoins += 10;
                x = rnd.Next(10, 150);
                coin1.Location = new Point(x, 40);

            }

            if (obj1.Bounds.IntersectsWith(coin2.Bounds))
            {
                
                scorecoins += 10;
                x = rnd.Next(150, 300);
                coin2.Location = new Point(x, 20);

            }
            label6.Text = Convert.ToString(scorecoins);
        }

        // White lines potition
        private void Track_line(int speed)
        {

            if (pictureBox1.Top >= 527 && pictureBox4.Top >= 527)
            {

                pictureBox1.Top = 0;
                pictureBox4.Top = 0;
            }
            else
            {

                pictureBox1.Top += speed;
                pictureBox4.Top += speed;
            }

            if (pictureBox2.Top >= 527 && pictureBox5.Top >= 527)
            {

                pictureBox2.Top = 0;
                pictureBox5.Top = 0;
            }
            else
            {

                pictureBox2.Top += speed;
                pictureBox5.Top += speed;
            }

            if (pictureBox3.Top >= 527 && pictureBox6.Top >= 527)
            {

                pictureBox3.Top = 0;
                pictureBox6.Top = 0;
            }
            else
            {

                pictureBox3.Top += speed;
                pictureBox6.Top += speed;
            }



        }
        // Obsacles movement
        private void Obsacles_line(int speed)
        {
            Random rnd = new Random();
            int x;
            if (obstacle.Top >= 500)
            {
                x = rnd.Next(20, 300);
                obstacle.Location = new Point(x, 0);
            }
            else
            {
                obstacle.Top += speed;
            }


        }
        // Coin movement
        private void Track_coin(int speed)
        {
            Random rnd = new Random();
            int x, y;
            if (coin1.Top >= 500)
            {
                x = rnd.Next(10, 150);
                coin1.Location = new Point(x, 40);
            }
            else
            {
                coin1.Top += speed;
            }


            if (coin2.Top >= 500)
            {
                y = rnd.Next(150, 300);
                coin2.Location = new Point(y, 20);
            }
            else
            {
                coin2.Top += speed;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Track_line(playerspeed);
            Obsacles_line(playerspeed);
            Track_coin(playerspeed);
            CoinsAdd();
            Gameover();

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (obj1.Left > 40)
                {
                    obj1.Left += -60;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (obj1.Right < 305)
                {
                    obj1.Left += 60;
                }
            }

            else if (e.KeyCode == Keys.Down)
            {
                if (playerspeed > 0)
                {
                    playerspeed--;
                }

            }
            else if (e.KeyCode == Keys.Up)
            {
                if (playerspeed <= 20)
                {
                    playerspeed++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Visible = false;
            obj1.Location = new Point(159, 383);
            obstacle.Location = new Point(159, 23);
            this.KeyPreview = true;

        }

        private void obstacle_Click(object sender, EventArgs e)
        {

        }

        private void labelscore_Click(object sender, EventArgs e)
        {

        }
    }

}
