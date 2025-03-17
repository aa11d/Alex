using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lapfordito
{
    public partial class Form1 : Form
    {
        PictureBox[,] lapok;
        public Form1()
        {
            InitializeComponent();
            // A tömb inicializálása a konstruktorban
            lapok = new PictureBox[4, 4]
            {
                { pictureBox1, pictureBox2, pictureBox3, pictureBox4 },
                { pictureBox5, pictureBox6, pictureBox7, pictureBox8 },
                { pictureBox9, pictureBox10, pictureBox11, pictureBox12 },
                { pictureBox13, pictureBox14, pictureBox15, pictureBox16 }
            };
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (global::System.Int32 j = 0; j < 4; j++)
                {
                    int ran = r.Next(0,2);
                    lapok[i,j].BackColor = ran == 0 ? Color.Green : Color.Yellow;
                }
            }
            //lapok[1, 2].BackColor = Color.Yellow;
            pos();
        }
        private void pos()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Méret beállítása
                    lapok[i, j].Size = new Size(70, 70);
                    // Pozíció beállítása: (oszlop * 40, sor * 40)
                    lapok[i, j].Location = new Point(100 * j, 100 * i);
                }
            }
        }
        public void fordito(int x, int y)
        {
            //Color newColor = lapok[x, y].BackColor == Color.Yellow ? Color.Green : Color.Yellow;

            // Szomszédos mezők módosítása az x tengely mentén
            if (x > 0) lapok[x - 1, y].BackColor = lapok[x - 1, y].BackColor == Color.Green ? Color.Yellow : Color.Green; // Balra
            if (x < 3) lapok[x + 1, y].BackColor = lapok[x + 1, y].BackColor == Color.Green ? Color.Yellow : Color.Green; // Jobbra

            // Szomszédos mezők módosítása az y tengely mentén
            if (y > 0) lapok[x, y - 1].BackColor = lapok[x, y - 1].BackColor == Color.Green ? Color.Yellow : Color.Green; // Fel
            if (y < 3) lapok[x, y + 1].BackColor = lapok[x, y + 1].BackColor == Color.Green ? Color.Yellow : Color.Green; // Le
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fordito(0, 0);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fordito(1, 0);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fordito(2, 0);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fordito(3, 0);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            fordito(0, 1);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            fordito(1, 1);
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            fordito(2,1);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            fordito(3, 1);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            fordito(1, 2);
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            fordito(0, 2);
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            fordito(2, 2);
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            fordito(3, 2);
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            fordito(0, 3);
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            fordito(1, 3);
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            fordito(2, 3);
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            fordito(3, 3);
        }
    }
}