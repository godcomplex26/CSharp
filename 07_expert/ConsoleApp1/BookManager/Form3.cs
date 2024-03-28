using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookManager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 화면 중앙에 오게 하기

            userBindingSource.Clear();
            foreach (User user in DataManager.Users)
            {
                userBindingSource.Add(user);
            }

            // 데이터 그리드 설정
            // dataGridView1.DataSource = DataManager.Users;
            // dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            
            // 버튼 설정
            button1.Click += (sender, e) =>
            {
                // 추가 버튼    
                try
                {
                    if (DataManager.Users.Exists((x) => x.Id == int.Parse(textBox1.Text)))
                    {
                        MessageBox.Show("사용자 ID가 겹칩니다.");
                    }
                    else
                    {
                        User user = new User()
                        {
                            Id = int.Parse(textBox1.Text),
                            Name = textBox2.Text
                        };
                        DataManager.Users.Add(user);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Users;
                        DataManager.Save();
                        dataGridView1.Refresh();
                    }
                }
                catch (Exception ex)
                {

                }
            };

            button2.Click += (sender, e) =>
            {
                // 수정 버튼
                try
                {
                    User user = DataManager.Users.Single((x) => x.Id == int.Parse(textBox1.Text));
                    user.Name = textBox2.Text;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                    dataGridView1.Refresh();
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 사용자입니다.");
                }
            };

            button3.Click += (sender, e) =>
            {
                // 삭제 버튼 -> 책을 빌린 상태에서는 삭제가 안 되도록 처리 필요
                try
                {
                    User user = DataManager.Users.Single((x) => x.Id == int.Parse(textBox1.Text));
                    DataManager.Users.Remove(user);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("존재하지 않는 사용자입니다.");
                }
            };
        }

/*        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
                User user = dataGridView1.CurrentRow.DataBoundItem as User;
                textBox1.Text = user.Id.ToString();
                textBox2.Text = user.Name;
            }
            catch (Exception ex)
            {

            }
        }*/

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
            User user = dataGridView1.CurrentRow.DataBoundItem as User;
            textBox1.Text = user.Id.ToString();
            textBox2.Text = user.Name;
        }
    }
}
