using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modal3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(String text)
        {
            InitializeComponent();
            if(text.Equals("red"))
            {
                this.BackColor = Color.Red;
            }
            
            if(text.Equals("blue"))
            {
                this.BackColor = Color.Blue;
            }
        }
    }
}
