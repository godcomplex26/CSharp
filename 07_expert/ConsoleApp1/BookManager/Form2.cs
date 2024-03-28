using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // 화면 중앙에 오게 하기

            bookBindingSource.Clear();
            foreach (Book book in DataManager.Books)
            {
                bookBindingSource.Add(book);
            }

            // 데이터 그리드 설정
            // dataGridView1.DataSource = DataManager.Books;
            // dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            // 버튼 설정
            button1.Click += (sender, e) =>
            {
                // 추가 버튼
                try
                { // Exists() 메서드는 리스트에 조건에 맞는 객체가 있는지 확인하는 메서드
                    if (DataManager.Books.Exists((x) => x.Isbn == textBox1.Text))
                    {
                        MessageBox.Show("이미 존재하는 도서입니다.");
                    }
                    else
                    {
                        Book book = new Book();
                        book.Isbn = textBox1.Text;
                        book.Name = textBox2.Text;
                        book.Publisher = textBox3.Text;
                        int.TryParse(textBox4.Text, out int page);
                        if(page <= 0)
                        {
                            throw new Exception("페이지 값이 잘못 됐습니다.");
                        }
                        book.Page = page;
                        DataManager.Books.Add(book);
                        bookBindingSource.Add(book);
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
                { // c#에서는 string 비교를 equals, == 둘 다 가능
                    // java에서는 string 비교는 equals
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBox1.Text);
                    book.Name = textBox2.Text;
                    book.Publisher = textBox3.Text;
                    book.Page = int.Parse(textBox4.Text);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("존재하지 않는 도서입니다.");
                }
            };

            button3.Click += (sender, e) =>
            {
                // 삭제 버튼
                try
                {
                    Book book = DataManager.Books.Single((x) => x.Isbn == textBox1.Text);
                    DataManager.Books.Remove(book);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("존재하지 않는 도서입니다.");
                }
            };
        }
/*        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
                Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
                textBox1.Text = book.Isbn;
                textBox2.Text = book.Name;
                textBox3.Text = book.Publisher;
                textBox4.Text = book.Page.ToString();
            }
            catch (Exception ex)
            {

            }
        }
*/
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 그리드의 셀이 선택되면 텍스트 박스에 글자 지정
            Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
            textBox1.Text = book.Isbn;
            textBox2.Text = book.Name;
            textBox3.Text = book.Publisher;
            textBox4.Text = book.Page.ToString();
        }
    }
}
