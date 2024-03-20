using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp002_2
{
    public partial class Form1 : Form
    {
        public List<string> list = new List<string>();  
        public Form1()
        {
            InitializeComponent();
            ListText.Text = "";

            Console.WriteLine("안녕!"); // f5 하면 나오고, ctrl+f5에는 안나옴
            Random rn = new Random(); 
            button1.Text = rn.Next (100).ToString ();
            button5.Text = button1.Text;
            button2.Text = rn.Next(100).ToString();
            button6.Text = button2.Text;
            button3.Text = rn.Next(100).ToString();
            button7.Text = button3.Text;
            button4.Text = rn.Next(100).ToString();
            button8.Text = button4.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Add(button1.Text);
            ListText.Text = "";
            foreach(var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Add(button2.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list.Add(button3.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list.Add(button4.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            list.Remove(button5.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            list.Remove(button6.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            list.Remove(button7.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            list.Remove(button8.Text);
            ListText.Text = "";
            foreach (var item in list)
            {
                ListText.Text += item + " ";
            }
        }
    }
}
