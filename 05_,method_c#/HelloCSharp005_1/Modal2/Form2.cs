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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // 생성자 오버로딩
        // 커스터마이징 form의 장점 중 하나로서 label 등의 컴포넌트 자유롭게 배열 가능하고
        // 텍스트 등의 데이터 등도 전송할 수 있다.
        public Form2(String text)
        {
            InitializeComponent(); // 필수
            label1.Text = text;
            label2.Text = text;
        }
    }
}
