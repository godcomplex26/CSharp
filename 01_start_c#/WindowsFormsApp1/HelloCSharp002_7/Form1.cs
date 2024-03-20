using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "정답";
            label2.Text = "결과";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int rNum = rn.Next(10);
            int num = int.Parse(textBox1.Text);

            label1.Text = rNum.ToString();

            if (num == rNum)
            {
                label2.Text = "성공";
            }
            else 
            {
                label2.Text = "실패";
            }
        }
    }
}
