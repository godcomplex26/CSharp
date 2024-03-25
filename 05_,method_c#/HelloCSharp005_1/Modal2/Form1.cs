using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 창을 띄우는 유형
            // 모달(Modal) // 다른 화면 조작 불가능, 코드가 멈춤
            // 모달리스(Modeless) // 다른 화면 조작 가능, 코드가 멈추지 않음
                
            // 디자인 면에서나 버튼 개수 면에서 제한이 많음
            // 팝업 창에서 뭔가를 입력 받고 싶은데 그런 기능은 없음
            MessageBox.Show("경고 메시지"); // 메시지 박스는 기본적으로 모달임
            MessageBox.Show("위험 메시지", "위험!"); // "메시지", "메시지박스 이름"
            DialogResult result;

            do
            {
                result = MessageBox.Show(
                    "다시 시도?", "시도문의", MessageBoxButtons.RetryCancel);
            } while (result == DialogResult.Retry); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MessageBox.Show("잠시 숨겼습니다."); // 모달을 활용하는 방법 중 하나
            // 코드가 멈춤.
            // 창을 닫아야 Show()가 호출됨.
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            // new Form2("10 != 1O").ShowDialog(); // 모달, Form2만 보일 것
            new Form2("10 != 1O").Show(); // 모달리스, 창이 둘 다 나타날 것
            Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true; // 자기 자신을 Mdi 컨테이너로 만듦.
            Form2 f = new Form2();
            f.MdiParent = this; // 현재 창을 부모 창으로 지정
            f.Show();
        }
    }
}
