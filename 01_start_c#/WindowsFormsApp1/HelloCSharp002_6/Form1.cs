﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int num = rn.Next(8);

            string[] fruits = { "사과", "딸기", "배", "포도", "복숭아", "수박", "체리", "꽝" };
            label1.Text = fruits[num];
        }
    }
}
