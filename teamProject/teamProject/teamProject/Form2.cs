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

namespace teamProject
{
    public partial class Form2 : Form
    {
/*
        // 데이터 표시 포맷, 시간은 초까지, 소수점은 두 자리까지
        public void Format()
        {
            dataGridView1.Columns["datetime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            // gridview1 소수점 이하 두 자리까지만 표시되도록 설정
            string[] columns = { "ReactA_Temp", "ReactB_Temp", "ReactC_Temp", "ReactD_Temp", "ReactE_Temp",
            "ReactF_Temp", "ReactF_PH", "Power", "CurrentA", "CurrentB","CurrentC"};
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView1.Columns[columns[i]].DefaultCellStyle.Format = "N2";
            }
        }

        // 화면 리프레시
        public void reScreen()
        {
            dataGridView1.DataSource = null;
            DataManager.Load();
            if (DataManager.datas.Count > 0)
            {
                dataGridView1.DataSource = DataManager.datas;
                Format();
            }
        }

        public void reScreen(string c1, string c2, string c3)
        {
            dataGridView1.DataSource = null;
            DataManager.Load(c1, c2, c3);
            if (DataManager.datas.Count > 0)
            {
                dataGridView1.DataSource = DataManager.datas;
                Format();
            }
        }
*/
        public Form2()
        {
            InitializeComponent();
            Utils.reScreen(dataGridView1, "PData");
        }

        // 셀 선택 시 textBox에 선택값 할당
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PData data = dataGridView1.CurrentRow.DataBoundItem as PData;
            textBox1.Text = data.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            textBox2.Text = data.ReactA_Temp.ToString();
            textBox3.Text = data.ReactB_Temp.ToString();
            textBox4.Text = data.ReactC_Temp.ToString();
            textBox5.Text = data.ReactD_Temp.ToString();
            textBox6.Text = data.ReactE_Temp.ToString();
            textBox7.Text = data.ReactF_Temp.ToString();
            textBox8.Text = data.ReactF_PH.ToString();
            textBox9.Text = data.Power.ToString();
            textBox10.Text = data.CurrentA.ToString();
            textBox11.Text = data.CurrentB.ToString();
            textBox12.Text = data.CurrentC.ToString();
        }

        // 선택 데이터 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            // textBox1.Text와 동일한 datetime을 갖는 PData 객체 찾기
            PData data = DataManager.datas.SingleOrDefault(x => x.datetime.ToString("yyyy-MM-dd HH:mm:ss.fff") == textBox1.Text);
            if (data != null)
            {
                DataManager.Delete(data);
                MessageBox.Show($"{textBox1.Text} 데이터가 삭제 되었습니다.");
                Utils.reScreen(dataGridView1, "PData");
            }
            else
            {
                MessageBox.Show("해당하는 데이터가 없습니다.");
            }
        }

        // 랜덤 데이터 생성
        public PData makeRandom()
        {
            Random rn = new Random();

            PData data = new PData();
            data.datetime = DateTime.Now;
            data.ReactA_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
            data.ReactB_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
            data.ReactC_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
            data.ReactD_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
            data.ReactE_Temp = rn.NextDouble() * (21.0 - 19.0) + 19.0;
            data.ReactF_Temp = rn.NextDouble() * (10.0 - 5.0) + 5.0;
            data.ReactF_PH = rn.NextDouble() * (2.0 - 1.0) + 1.0;
            data.Power = rn.NextDouble() * (1400.0 - 1300.0) + 1300.0;
            data.CurrentA = rn.NextDouble() * (0.4 - 0.2) + 0.2;
            data.CurrentB = rn.NextDouble() * (1.8 - 1.6) + 1.6;
            data.CurrentC = rn.NextDouble() * (1.4 - 1.2) + 1.2;

            return data;
        }

        // 테스트 데이터 n개 입력
        private void button4_Click(object sender, EventArgs e)
        {
            int count = 1;
            if (!textBox13.Text.Trim().Equals(""))
            {
                count = int.Parse(textBox13.Text);
            }

            // 확인 대화 상자 표시
            DialogResult result = MessageBox.Show($"테스트 데이터를 {count}개 생성하시겠습니까?\n(이 작업은 수 초 내지 수 분이 소요될 수 있습니다.)",
                "생성", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // 생성을 선택한 경우
            if (result == DialogResult.OK)
            {
                // 테스트 데이터 생성 및 저장
                for (int i = 0; i < count; i++)
                {
                    PData random = makeRandom();
                    Thread.Sleep(100);
                    DataManager.Save(random);
                }

                // 데이터 그리드뷰 다시 불러오기
                Utils.reScreen(dataGridView1, "PData");

                // 사용자에게 완료 메시지 표시
                textBox13.Text = "";
                MessageBox.Show($"테스트 데이터가 {count}개 생성 되었습니다.");
            }
            else // 취소를 선택한 경우
            {
                MessageBox.Show("테스트 데이터 생성이 취소 되었습니다.");
            }
        }
    }
}
