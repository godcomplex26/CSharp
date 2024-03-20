using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rNum.Text = "";
            result.Text = "";
            select.Text = "";
        }

        private void scissors_Click(object sender, EventArgs e)
        {
            select.Text = "가위";
        }

        private void rock_Click(object sender, EventArgs e)
        {
            select.Text = "바위";
        }

        private void paper_Click(object sender, EventArgs e)
        {
            select.Text = "보";
        }

        private void submit_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int n = rn.Next(3); // 0, 1, 2 중 랜덤
            
            if (n == 0)
            {
                rNum.Text = "가위";
            }
            if (n == 1)
            {
                rNum.Text = "바위";
            }
            if (n == 2)
            {
                rNum.Text = "보";
            }
            
            if (n == 0 && select.Text.Equals("가위") || 
                n == 1 && select.Text.Equals("바위") ||
                n == 2 && select.Text.Equals("보"))
            {
                result.Text = "무승부";
            }

            if (n == 0 && select.Text.Equals("바위") ||
                n == 1 && select.Text.Equals("보") ||
                n == 2 && select.Text.Equals("가위"))
            {
                result.Text = "승리";
            }

            if (n == 0 && select.Text.Equals("보") ||
                n == 1 && select.Text.Equals("가위") ||
                n == 2 && select.Text.Equals("바위"))
            {
                result.Text = "패배";
            }
        }
    }
}
