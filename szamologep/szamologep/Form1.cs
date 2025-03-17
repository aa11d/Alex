using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szamologep
{
    public partial class Form1 : Form
    {
        public double res = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] operators =  new char[4] { '+', '-', '/', '*' };
            string num1 = "";
            string num2 = "";
            char op = ' ';
            bool firstnum = true;
            for (int i = 0; i < textBox1.TextLength; i++)
            {
                if (operators.Contains(textBox1.Text[i]))
                {
                    firstnum = false;
                    op = textBox1.Text[i];
                    i++;
                }
                if(firstnum)
                {
                    num1 += Convert.ToString(textBox1.Text[i]);
                }
                else
                {
                    num2 += Convert.ToString(textBox1.Text[i]);
                }
            }
            if(op == '+')
            {
                res = Convert.ToDouble(num1) + Convert.ToDouble(num2);
            }else if(op == '-')
            {
                res = Convert.ToDouble(num1) - Convert.ToDouble(num2);
            }else if(op == '/')
            {
                res = Convert.ToDouble(num1) / Convert.ToDouble(num2);
            }else if(op == '*')
            {
                res = Convert.ToDouble(num1) * Convert.ToDouble(num2);
            }
            else
            {
                res = 000.000;
            }
            textBox1.Text = Convert.ToString(res);
        }
    }
}