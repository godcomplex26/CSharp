using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                dataGridView1.Columns["Column_hakbeon"].HeaderText = "학!번";
                dataGridView1.Columns["Column_name"].HeaderText = "이!름";
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add(textBox4.Text, textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentBindingSource.Add(new Student() { name = textBox6.Text, hakbeon = textBox5.Text });
        }

        List<Student> students = new List<Student>();

        private void button5_Click(object sender, EventArgs e)
        {
            students.Add(new Student() { name = textBox7.Text, hakbeon= textBox8.Text });
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = students;
        }
    }
}
