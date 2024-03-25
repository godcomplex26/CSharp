using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 라디오 버튼 생성
            CheckBox checkBox1 = new CheckBox();
            CheckBox checkBox2 = new CheckBox();
            CheckBox checkBox3 = new CheckBox();
            Button button = new Button();

            // 요소의 속성을 설정
            checkBox1.Text = "감자";
            checkBox2.Text = "고구마";
            checkBox3.Text = "토마토";
            button.Text = "클릭";

            checkBox1.Location = new Point(10, 10);
            checkBox2.Location = new Point(10, 40);
            checkBox3.Location = new Point(10, 70);
            button.Location = new Point(10, 100);

            button.Click += ButtonClick;

            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(button);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            List<String> list = new List<String>();

            foreach (var item in Controls) 
            {
                if(item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    // 체크된 항목들을 리스트에 추가하고
                    if(checkBox.Checked)
                    {
                        list.Add(checkBox.Text);
                    }
                }
            }

            // 리스트의 항목들을 문자열로 출력, ","로 구분
            MessageBox.Show(String.Join(",", list));
        }
    }
}
