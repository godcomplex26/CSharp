using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace teamProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Utils.reScreen(dataGridView1, "QData");
        }

        // 셀 선택 시 textBox에 선택값 할당
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            QData data = dataGridView1.CurrentRow.DataBoundItem as QData;
            textBox1.Text = data.date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            textBox2.Text = data.weight.ToString();
            textBox3.Text = data.water.ToString();
            textBox4.Text = data.material.ToString();
            textBox5.Text = data.HSO.ToString();
            textBox6.Text = data.pH.ToString();
        }

        // 선택 데이터 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            // textBox1.Text와 동일한 datetime을 갖는 PData 객체 찾기
            QData data = DataManager.datasQ.SingleOrDefault(x => x.date.ToString("yyyy-MM-dd HH:mm:ss.fff") == textBox1.Text);
            if (data != null)
            {
                DataManager.Delete(data);
                MessageBox.Show($"{textBox1.Text} 데이터가 삭제 되었습니다.");
                Utils.reScreen(dataGridView1, "QData");
            }
            else
            {
                MessageBox.Show("해당하는 데이터가 없습니다.");
            }
        }
    }
}
