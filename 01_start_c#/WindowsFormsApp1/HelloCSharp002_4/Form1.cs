using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Student> students = new List<Student>();
            students.Add(new Student() {  name = "이종운", grade = 1});
            students.Add(new Student() {  name = "종운이", grade = 2});
            students.Add(new Student() {  name = "운종이", grade = 3});
            students.Add(new Student() {  name = "운운이", grade = 4});
            students.Add(new Student() {  name = "종종이", grade = 1});
            students.Add(new Student() {  name = "이이이", grade = 2});

            for(int i = 0; i < students.Count; i++) 
            {
                Label label = new Label();
                label.Text = $"{students[i].grade}학년 {students[i].name} 학생";
                label.AutoSize = true;
                label.Location = new Point(13, 13 + (23 + 3) * i);
                Controls.Add(label);
            }

            for(int i = students.Count-1;  i >= 0; i--)
            {
                if (students[i].grade > 1)
                {
                    students.RemoveAt(i);
                }
            }

            for(int i = 0; i < students.Count; i++)
            {
                Label label = new Label();
                label.Text = $"{students[i].grade}학년 {students[i].name} 학생";
                label.AutoSize = true;
                label.Location = new Point(130, 13 + (23 + 3) * i);
                Controls.Add(label);
            }
        }
    }
    class Student
    {
        public string name;
        public int grade;
    }
}
