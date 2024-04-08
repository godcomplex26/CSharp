using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace teamProject
{
    public partial class Form0 : Form
    {
        private Form1 form1;
//        private Form7 form7;
        private Thread loadingThread;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int currentIndex = 0;

        // 이미지 배열 혹은 리스트를 만듭니다.
        private Image[] images = { Properties.Resources.image1, Properties.Resources.image2, Properties.Resources.image3, Properties.Resources.image4};

        public Form0()
        {
            InitializeComponent();
            label1.Text = "";

            // 타이머 설정
            timer.Interval = 1000; // 1초마다 변경
            timer.Tick += Timer_Tick;
            timer.Start();

            // 초기 이미지 표시
            pictureBox2.Image = images[currentIndex];
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 다음 이미지로 변경
            currentIndex = (currentIndex + 1) % images.Length;
            pictureBox2.Image = images[currentIndex];
        }
/*        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            form1.Show();
        }*/


        private async void button1_Click(object sender, EventArgs e)
        {
            // 버튼 클릭 시 로딩 시작
            label1.Text = "로딩중..";
            progressBar1.Style = ProgressBarStyle.Marquee; // Marquee 스타일은 애니메이션 형태의 로딩바입니다.
            progressBar1.MarqueeAnimationSpeed = 30; // 로딩바의 애니메이션 속도를 조절합니다.

            // Form1을 비동기적으로 생성하고 표시합니다.
            await Task.Run(() =>
            {

                // 시간이 걸리는 작업 수행, Form1, 7 생성
//             Thread.Sleep(5000); // 5초 동안 대기
                

/*                
                 // Form1을 UI 스레드에서 표시합니다.
                this.Invoke((MethodInvoker)delegate
                {
                    form1.Show();
                });
*/
            });

            // Form0을 숨깁니다.
            form1.Show();
            this.Hide();
        }
    }
}
