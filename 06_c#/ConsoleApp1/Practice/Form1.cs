using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Practice
{
    public partial class Form1 : Form
    {
        string directory1 = @"C:\test\test1.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (textBox2.Text.Equals(""))
            {
                File.WriteAllText(directory1, textBox1.Text);
            } else
            {
                File.WriteAllText(textBox2.Text, textBox1.Text);   
            }             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                label2.Text = File.ReadAllText(directory1);
            }
            else
            {
                label2.Text = File.ReadAllText(textBox2.Text);
            }
        }
    }
}
