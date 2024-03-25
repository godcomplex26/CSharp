using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Label label = new Label()
            {
                Text = "글자",
                Location = new Point(10, 10)
            };

            LinkLabel linkLabel = new LinkLabel()
            {
                Text = "글자",
                Location = new Point(10, 50)
            };

            linkLabel.Click += LabelClick;

            LinkLabel linkLabel2 = new LinkLabel()
            {
                Text = "글자",
                Location = new Point(10, 90)
            };

            linkLabel2.Click += LabelClick2;

            Controls.Add(label);
            Controls.Add(linkLabel);
            Controls.Add(linkLabel2);
        }

        // 웹페이지 링크
        private void LabelClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.naver.com");
        }

        // 응용 프로그램 링크
        private void LabelClick2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe");
        }
    }
}
