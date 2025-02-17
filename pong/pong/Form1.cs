using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class Form1 : Form
    {
        private int[] grav = { 3, 3, 3 };
        int plsc = 0;
        int pl2sc = 0;
        private const int a = 25;

        private int[] posy = { 100, 200, 300 };
        private int[] posx = { 375, 375, 375 };
        private int[] velx = { 1, 2, 3 };
        private PictureBox[] pctbxs = new PictureBox[3];
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Start();
            KeyPreview = true;
            label1.Text = $"{plsc}:0";
            pctbxs[0] = pictureBox1;
            pctbxs[1] = pictureBox4;
            pctbxs[2] = pictureBox5;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < pctbxs.Length; i++)
            {
                if (pctbxs[i].Top + a >= ClientSize.Height) {/*posY = ClientSize.Height - pctbxs[i].Height;*/ grav[i] *= -1; }
                if (pctbxs[i].Left + pctbxs[i].Width >= 800) { posy[i] = 225; posx[i] = 400; pl2sc++; label1.Text = $"{plsc}:{pl2sc}"; }
                if (pctbxs[i].Top <= 0) { grav[i] *= -1; }  //labda jobb >= player bal && labda top >= player top && labda top <= player alja                                                                 /*labda jobb, player jobb oldala*/                /*labda teteje >= player teteje*/     /*labda teteje <= player alja*/
                if ((pctbxs[i].Left + a >= pictureBox2.Left && pctbxs[i].Top >= pictureBox2.Top && pctbxs[i].Top <= pictureBox2.Top + pictureBox2.Height) || (pctbxs[i].Left <= pictureBox3.Left + pictureBox3.Width && pctbxs[i].Top >= pictureBox3.Top && pctbxs[i].Top <= pictureBox3.Top + pictureBox3.Height)) { /*posX = ClientSize.Width - pctbxs[i].Width;*/ velx[i] *= -1; }
                if (pctbxs[i].Left <= 0) { posy[i] = 400; posx[i] = ClientSize.Width / 2; plsc++; label1.Text = $"{plsc}:{pl2sc}"; }
            }
            for (int i = 0; i < pctbxs.Length; i++)
            {
                move(pctbxs[i], i);
            }
            int min = 0;
            for (int i = 0; i < 2; i++)
            {
                if (posx[i] > posx[i + 1])
                {
                    min = i;
                }
            }
            //pictureBox2.Top = posy[min];
        }
        public void move(PictureBox box, int i)
        {
            posy[i] += grav[i];
            box.Top = posy[i];
            posx[i] += velx[i];
            box.Left = posx[i];
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                pictureBox3.Top -= 10;
            }
            if (e.KeyCode == Keys.S)
            {
                pictureBox3.Top += 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                pictureBox2.Top -= 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox2.Top += 10;
            }
        }
    }
}
