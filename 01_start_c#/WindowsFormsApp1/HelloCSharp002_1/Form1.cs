using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 6개 번호 추첨
            Random rn = new Random();
            List<int> nums = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                int num = rn.Next(1, 46);
                if (!nums.Contains(num)) 
                { 
                    nums.Add(num);
                }
                else
                {
                    i--;
                }
            }
            nums.Sort(); // 오름차순 정렬

            // 추첨한 숫자 label에 삽입
            Label[] labels = { label1, label2, label3, label4, label5, label6 };
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = nums[i].ToString();
            }

            // 보너스 번호 추첨
            int bNum = 0;
            do
            {
                bNum = rn.Next(1, 46);
                label7.Text = bNum.ToString();
            } while (nums.Contains(bNum));
        }
    }
}
