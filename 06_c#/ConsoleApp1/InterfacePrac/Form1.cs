using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfacePrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Product> products = new List<Product>();
            products.Add(new Product() { Name = "고구마", Price = 100 });
            products.Add(new Product() { Name = "파", Price = 500 });
            products.Add(new Product() { Name = "감자", Price = 100 });

            int i = 0;
            foreach (Product product in products)
            {
                Label l = new Label();
                l.Location = new Point(10, 10 + (30 * i));
                l.Text = product.ToString();
                l.AutoSize = true; // 글자 잘림 방지
                Controls.Add(l);
                i++;
            }

            i = 0;
            products.Sort(); // 가격 기준으로 정렬됨
            foreach (Product product in products)
            {
                Label l = new Label();
                l.Location = new Point(200, 10 + (30 * i));
                l.Text = product.ToString();
                l.AutoSize = true;
                Controls.Add(l);
                i++;
            }

            // 다형성 응용하기

            IComparable p = new Product();
        }
    }
}
