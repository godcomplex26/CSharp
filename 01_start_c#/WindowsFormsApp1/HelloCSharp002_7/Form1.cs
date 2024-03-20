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
        }

        Random rn = new Random();
        int rNum;

        private void button1_Click(object sender, EventArgs e)
        {
           int num = int.Parse(textBox1.Text);

            if (num == rNum)
            {
                MessageBox.Show("정답");
                label1.Text = rNum.ToString();
            }
            
            if (num > rNum)
            {
                MessageBox.Show("다운");
            }

            if(num < rNum)
            {
                MessageBox.Show("업");
            }
        }

        // 1~9까지 난수 생성
        private void start_Click(object sender, EventArgs e)
        {
            rNum = rn.Next(9)+1;
        }
    }
}
