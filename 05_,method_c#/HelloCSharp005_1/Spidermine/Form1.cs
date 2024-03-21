using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spidermine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            button1.Text = "시작";
        }

        int time;
        int rNum1;
        int rNum2;
        List<Button> buttonList = new List<Button>();

        private void button1_Click(object sender, EventArgs e)
        {
            if(buttonList != null)
            {
                foreach(var button in buttonList)
                {
                    Controls.Remove(button);
                }
            }

            label1.Text = "";
            button1.Text = "시작";
            time = 30;
            label1.Text = time + "초 남음";
            timer1.Enabled = true;

            Random rn = new Random();
            rNum1 = rn.Next(5);
            rNum2 = rn.Next(5);

            for (int i = 0; i < 5; i++)
            { 
                for(int j = 0; j < 5; j++) 
                {
                    Button b = new Button();
                    b.Text = "??";
                    b.Location = new Point(250 + 80*j , 13 + (23 + 3) * i);
                    Controls.Add(b);
                    buttonList.Add(b);

                    // 버튼 클릭 이벤트 핸들러 등록
                    if (i == rNum1 && j == rNum2) // 지뢰 버튼
                        b.Click += new EventHandler(Button_Click_m);
                    else
                        b.Click += new EventHandler(Button_Click_Default);
                }     
            }
        }

        // 지뢰 버튼의 클릭 이벤트 핸들러
        private void Button_Click_m(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false; // 버튼 비활성화
            button.Text = "지뢰"; // 버튼 텍스트 변경
            timer1.Enabled = false;
            MessageBox.Show("지뢰 입니다.");
            button1.Text = "다시하기";
        }

        // 나머지 버튼의 클릭 이벤트 핸들러
        private void Button_Click_Default(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Enabled = false; // 버튼 비활성화
            button.Text = "OK"; // 버튼 텍스트 변경
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label1.Text = time + "초 남음";

            if (time <= 10)
            {
                label1.ForeColor = Color.Red;
            }

            if (time == 0)
            {
                label1.ForeColor = Color.Black;
                timer1.Enabled = false;
                MessageBox.Show("TimeOVer");
                button1.Text = "다시하기";
            }
        }
    }
}
