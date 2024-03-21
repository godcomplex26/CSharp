using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace NumberGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            button1.Text = "시작";
            button2.Text = "제출";
        }

        int time;
        int rNum;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label1.Text = time + "초 남음";

            if (time == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("TimeOVer");
                button1.Text = "다시하기";
            }
        }

        // 시작 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            label2.Text = "";
            button1.Text = "시작";
            time = 10;
            label1.Text = time + "초 남음";
            timer1.Enabled = true;
           
            Random rn = new Random();
            rNum = rn.Next(10) + 1;
        }

        // 제출 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);

            if (num == rNum)
            {
                MessageBox.Show("정답");
                label2.Text = "정답 : " +  rNum.ToString();
                timer1.Enabled = false;
                button1.Text = "다시하기";
            }

            if (num > rNum)
            {
                MessageBox.Show("다운");
            }

            if (num < rNum)
            {
                MessageBox.Show("업");
            }
        }
    }
}
