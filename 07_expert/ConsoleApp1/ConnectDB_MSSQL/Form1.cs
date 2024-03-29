using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectDB_MSSQL
{
    public partial class Form1 : Form
    {
        enum CRUD // 숫자에 이름 붙이는 것 -> sql 삽입 공격을 막기 위해서 sql에 사용되는 명령어를 암호화
        {
            INSERT, UPDATE=5, DELETE
        }
        public Form1()
        {
            InitializeComponent();
        }

        // DB 연결을 보여주기 위해서 form에다가 직접 쓰지만, 실제로는 DB연동을 위한 DBHelper와 DataManager 사용

        private SqlConnection conn = new SqlConnection();

        // 트랜잭션마다 연결 하기 -> 수행 -> 연결 끊기
        private void ConnectDB()
        {
            conn.ConnectionString = $"Data Source=({"local"}); " +
                $"Initial Catalog = {"ProjectDataBase"}; integrated Security = {"SSPI"}; Timeout={3}";
            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();
        }

        private void Query_Insert()
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand(); // SQL문 보낼 객체
                cmd.Connection = conn; // 어디로 연결할 지 지정
                cmd.Parameters.AddWithValue("@parameter1", textBox1.Text);
                cmd.Parameters.AddWithValue("@parameter2", textBox2.Text);
                cmd.CommandText = "insert into testTable values (@parameter1, @parameter2)"; // 전송할 SQL문
                cmd.ExecuteNonQuery(); // 쿼리 실행
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }          
        }

        private void Query_Select()
        {
            try
            {
                ConnectDB(); // DBMS 연결
                SqlCommand cmd = new SqlCommand(); // SQL문 보낼 객체
                cmd.Connection = conn; // 어디로 연결할 지 지정
                cmd.CommandText = "select * from testTable"; // 전송할 SQL문
                SqlDataAdapter da = new SqlDataAdapter(cmd); // SQL 데이터 처리할 변수
                DataSet ds = new DataSet(); // 실제 데이터 저장할 객체
                da.Fill(ds, "mytest"); // da를 통해서 ds에 mytest라는 이름으로 sql 결과문을 넣음
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "mytest";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        private void Query_Update()
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand(); // SQL문 보낼 객체
                cmd.Connection = conn; // 어디로 연결할 지 지정
                cmd.Parameters.AddWithValue("@parameter1", textBox1.Text);
                cmd.Parameters.AddWithValue("@parameter2", textBox2.Text);
                cmd.CommandText = "update testTable set name=(@parameter2) where hakbeon=(@parameter1)"; // 전송할 SQL문
                cmd.ExecuteNonQuery(); // 쿼리 실행
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    

        private void Query_Delete()
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand(); // SQL문 보낼 객체
                cmd.Connection = conn; // 어디로 연결할 지 지정
                cmd.Parameters.AddWithValue("@parameter1", textBox1.Text);
                cmd.Parameters.AddWithValue("@parameter2", textBox2.Text);
                cmd.CommandText = "delete testTable where hakbeon=(@parameter1) and name=(@parameter2)"; // 전송할 SQL문
                cmd.ExecuteNonQuery(); // 쿼리 실행
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        // 전체 출력
        private void button1_Click(object sender, EventArgs e)
        {
            Query_Select();
        }

        // 추가
        private void button2_Click(object sender, EventArgs e)
        {
            Query_Insert();
            MessageBox.Show("데이터 추가");
            Query_Select();
        }

        // 수정
        private void button3_Click(object sender, EventArgs e)
        {
            Query_Update();
            MessageBox.Show("데이터 수정");
            Query_Select();
        }

        // 삭제
        private void button4_Click(object sender, EventArgs e)
        {
            Query_Delete();
            MessageBox.Show("데이터 삭제");
            Query_Select();
        }

        // 셀 클릭시 텍스트 박스에 출력
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // 선택된 행의 각 셀의 값을 TextBox에 설정합니다.
                textBox1.Text = selectedRow.Cells["hakbeon"].Value.ToString();
                textBox2.Text = selectedRow.Cells["name"].Value.ToString();
            }
        }
    }
}
