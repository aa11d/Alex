using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szoveges
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> sorok = new List<string>();
            string filepath = "a.txt";
            //string szovegSoronkent = File.ReadAllLines(filepath);
            //szoveMegjelen.Lines = szovegSoronkent;
            StreamReader sr = new StreamReader(filepath);
            string sor = sr.ReadLine();
            while (sor != null)
            {
                if (sor != String.Empty) { sorok.Add(sor.Trim()); }
                sor = sr.ReadLine();
            }
            sr.Close();
            textBox2.Lines = sorok.ToArray();

            string[] nev = new string[sorok.Count];
            int[] szam = new int[sorok.Count];
            string[] varos = new string[sorok.Count];

            for (int i = 0; i < sorok.Count; i++)
            {
                string[] dar = sorok[i].Split(';');
                nev[i] = dar[0];
                szam[i] = int.Parse(dar[1]);
                varos[i] = dar[2];
            }

            int mapDat = szam.Max();
            int ki = Array.IndexOf(szam, mapDat);
            string sor1 = "maxpont: "+mapDat;
            textBox2.AppendText(sor1);
            string sor2 = "Kivót? "+nev[ki] + varos[ki];
            textBox2.AppendText(sor2);
        }
    }
}