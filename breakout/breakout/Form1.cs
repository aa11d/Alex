using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakout
{
    public partial class Form1 : Form
    {
        public static int a = 25;
        public static int b = 70;
        public static int c = 150;
        public static int d = 25;
        private int posy = 225;
        private int posx = 400;
        private int vely = -4;
        private int velx = -4;
        private int plposy = 400;
        private int plposx = 400;
        private PictureBox[] blocks = new PictureBox[5];
        private bool[] active = new bool[5];
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Enabled = true;
            timer1.Start();
            Inic();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox1.Top <= 0) { vely *= -1; }
            if(pictureBox1.Left + a >= ClientSize.Width) { velx *= -1; }
            if(pictureBox1.Left <= 0) { velx *= -1; }
            if(pictureBox1.Top + a >= plposy && pictureBox1.Left >= plposx-a  && pictureBox1.Left + a <= plposx + b + a) {  vely *= -1; posy -= 4; }
            if(pictureBox1.Top + a >= ClientSize.Height) { posy = ClientSize.Height/2; }
            blockcoll();
            move();
        }
        private void move()
        {
            posy += vely;
            pictureBox1.Top = posy;
            posx += velx;
            pictureBox1.Left = posx;
            pictureBox2.Left = plposx;
            pictureBox2.Top = plposy;
        }
        private void blockcoll()
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!active[i]) {  continue; }
                // Ellenőrizd a vertikális ütközést
                if (pictureBox1.Bottom >= blocks[i].Top && pictureBox1.Top <= blocks[i].Bottom)
                {
                    // Ellenőrizd a horizontális ütközést
                    if (pictureBox1.Right >= blocks[i].Left && pictureBox1.Left <= blocks[i].Right)
                    {
                        /*  if (blocks[i].Top + d <= pictureBox1.Top && pictureBox1.Left + a >= blocks[i].Left && pictureBox1.Left + a <= blocks[i].Left)  */
                        // Ütközés van, pattanás és blokk eltávolítása
                        vely *= -1; // Pattanás (inverz mozgás)

                        // A blokk eltávolítása
                        blocks[i].Hide();
                        active[i] = false;
                    }
                }
            }
        }

        private void Inic()
        {
            blocks = new PictureBox[] { pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7 };
            active = new bool[] {true,true,true,true,true };
            int space = 15;
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].Left = i * c + space;
                space += 5;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                plposx += 10;
            }
            if (e.KeyCode == Keys.A)
            {
                plposx -= 10;
            }
        }
    }
}