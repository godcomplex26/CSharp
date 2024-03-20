using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] lotto = new int[6];
            Random rn = new Random();
            for (int i = 0; i < lotto.Length; i++) 
            {
                int num = rn.Next(45) + 1; // 1~45 까지의 값
                if (lotto.Contains(num))
                {
                    i--;
                    continue;
                }
                lotto[i] = num;
            }
            int bns = rn.Next(45) + 1;
            while(lotto.Contains(bns))
            {
                bns = rn.Next(45) + 1;
            }
            Array.Sort(lotto); // 오름 차순 정렬
            label2.Text = String.Join(", ", lotto);
            label2.Text += ", 보너스 번호 : " + bns;
        }
    }
}
