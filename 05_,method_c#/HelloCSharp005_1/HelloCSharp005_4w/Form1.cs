using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp005_4w
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";

            button3.Click += Button3_Click;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text += "+";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text += "+";
            label2.Text = "";
            label3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text += "+";
            label3.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("yyyy년 mm월 dd일 HH시 mm분 ss초 fff");
        }
    }
}
