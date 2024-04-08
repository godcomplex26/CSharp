using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace teamProject
{
    public partial class Form7 : Form
    {
        //DataGridView dataGridView1;
        //DataGridView dataGridView2;
        public List<string> conditions = new List<string>();

        public Form7()
        {
            InitializeComponent();
            //this.TopLevel = false;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.Dock = DockStyle.Fill;
            //control.Controls.Add(this);
            //this.Show();

            tabPage1.Text = "PData";
            tabPage2.Text = "QData";

            listBox1.Items.AddRange(Utils.pdata);
            listBox2.Items.AddRange(operatorDict.Keys.ToArray());
        }

        //public Form7(DataGridView dataGridView1)
        //{
        //    this.dataGridView1 = dataGridView1;
        //    InitializeComponent();
        //}

        //public Form7(DataGridView dataGridView1, DataGridView dataGridView2)
        //{
        //    this.dataGridView1 = dataGridView1;
        //    this.dataGridView2 = dataGridView2;
        //    InitializeComponent();
        //}


        public void button2_Click(object sender, EventArgs e)
        {
            if (!textBox4.Text.Equals("") && listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                string column = listBox1.SelectedItem.ToString();
                string op = operatorDict[listBox2.SelectedItem.ToString()];
                string val = textBox4.Text;

                if (op.Equals("LIKE"))
                    val += "%";
                if (column.Equals("datetime") || column.Equals("date"))
                    val = $"'{val}'";

                string condition = $"{column} {op} {val}";
                if (IsValidWhereClause(condition))
                {
                    if (conditions.Count != 0)
                    {
                        if (conditions.Last().ToString().Equals("AND") || conditions.Last().ToString().Equals("OR"))
                        {
                            conditions.Add(condition);
                        }
                        else
                        {
                            conditions.Add("AND");
                            conditions.Add(condition);
                        }
                    }
                    else
                    {
                        conditions.Add(condition);
                    }
                }
                else
                {
                    MessageBox.Show("조건 구성이 올바르지 않습니다.");
                }
                textBox4.Clear();
            }
            condListRefresher();
        }

        public bool IsValidWhereClause(string whereClause)
        {
            string pattern = @"^(?:\s*\w+\s*(?:=|<>|>|<|>=|<=|LIKE|BETWEEN)\s*(?:'[^']*'|[\w\d%_\-\.]+(?:\.\d+)?)(?:\s*AND\s*(?:'[\w\d%_\-\.]+(?:\.\d+)?'))?(?:\s*ESCAPE\s*'\w')?(?:\s*AND\s*(?:'[\w\d%_\-\.]+(?:\.\d+)?'))?(?:\s*ESCAPE\s*'\w')?\s*(?:AND|OR)?\s*)*$";
            return Regex.IsMatch(whereClause, pattern, RegexOptions.IgnoreCase);
        }

        public void condListRefresher()
        {
            listBox3.Items.Clear();
            listBox3.Items.AddRange(conditions.ToArray());
        }

        public void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox3.SelectedItem != null)
                {
                    string selectedItem = listBox3.SelectedItem.ToString();
                    conditions.Remove(selectedItem);
                    condListRefresher();
                }
            }
        }

        public void button6_Click(object sender, EventArgs e) // AND
        {
            if (conditions.Count != 0)
                conditions.Add("AND");
            condListRefresher();
        }

        public void button7_Click(object sender, EventArgs e) // OR
        {
            if (conditions.Count != 0)
                conditions.Add("OR");
            condListRefresher();
        }

        public void button3_Click(object sender, EventArgs e) // 날짜 입력
        {
            Point buttonLocation = button3.PointToScreen(this.PointToScreen(Point.Empty));
            MonthCalendar calendar1 = new MonthCalendar();

            // MonthCalendar의 속성 설정
            calendar1.Location = new Point(button3.Location.X, 0);
            calendar1.ShowToday = true;
            calendar1.ShowTodayCircle = true;

            // MonthCalendar의 DateSelected 이벤트 처리
            calendar1.DateSelected += (s, args) =>
            {
                // 선택한 날짜를 yyyy-MM-dd 형식으로 가져오기
                string selectedDate = args.Start.ToString("yyyy-MM-dd");

                // 선택한 날짜를 TextBox에 추가
                textBox4.Text = selectedDate;

                // MonthCalendar 제거
                Controls.Remove(calendar1);
            };
            calendar1.KeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Escape)
                {
                    Controls.Remove(calendar1);
                }
            };


            System.Windows.Forms.Button xbutton = new System.Windows.Forms.Button();
            xbutton.Text = "x";
            xbutton.BackColor = Color.Transparent;
            xbutton.FlatStyle = FlatStyle.Flat;
            xbutton.Size = new System.Drawing.Size(20, 20);
            xbutton.Location = new Point(calendar1.Width + 20, calendar1.Height - 14);
            xbutton.Click += (s, args) =>
            {
                Controls.Remove(calendar1);
            };
            calendar1.Controls.Add(xbutton);

            // MonthCalendar를 폼에 추가
            this.Controls.Add(calendar1);

            // MonthCalendar를 맨 위로 가져오기
            calendar1.BringToFront();
            calendar1.Focus();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            conditions.Clear();
            condListRefresher();
        }

        public void finalQueryGen()
        {
            int len = conditions.Count();

            if (len != 0)
            {
                if (conditions[len - 1].Equals("AND") || conditions[len - 1].Equals("OR"))
                {
                    conditions.RemoveAt(len - 1);
                }
            }
            condListRefresher();
        }


        public void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Utils.pdata);
                //groupBox1.Controls.Add(button1);
                //groupBox1.Controls.Remove(button5);
                tabPage1.Controls.Add(listBox1);
                conditions.Clear();
                condListRefresher();
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Utils.qdata);
                //groupBox1.Controls.Add(button5);
                //groupBox1.Controls.Remove(button1);
                tabPage2.Controls.Add(listBox1);
                conditions.Clear();
                condListRefresher();
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > 0)
            {
                string temp;
                temp = conditions[listBox3.SelectedIndex];
                conditions[listBox3.SelectedIndex] = conditions[listBox3.SelectedIndex - 1];
                conditions[listBox3.SelectedIndex - 1] = temp;
                int afterindex = listBox3.SelectedIndex - 1;
                condListRefresher();
                listBox3.SelectedIndex = afterindex;
            }
        }

        public void button10_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0 && listBox3.SelectedIndex < conditions.Count - 1)
            {
                string temp;
                temp = conditions[listBox3.SelectedIndex];
                conditions[listBox3.SelectedIndex] = conditions[listBox3.SelectedIndex + 1];
                conditions[listBox3.SelectedIndex + 1] = temp;
                int afterindex = listBox3.SelectedIndex + 1;
                condListRefresher();
                listBox3.SelectedIndex = afterindex;
            }
        }

        public Control getTab()
        {
            return tabControl1;
        }

        public Control getGroupBox()
        {
            return groupBox1;
        }

        public int getLocationX()
        {
            return groupBox1.Location.X;
        }

        public int getLocationY()
        {
            return groupBox1.Location.Y;
        }

        public string getCurrentTab()
        {
            return tabControl1.SelectedTab.Text;
        }

        Dictionary<string, string> operatorDict = new Dictionary<string, string>
        {
            {"정확히 일치", "="},
            {"같거나 비슷함", "LIKE"},
            {"큼", ">"},
            {"크거나 같음", ">="},
            {"작음", "<"},
            {"작거나 같음", "<="}
        };
    }
}