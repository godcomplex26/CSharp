using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }

        public override string ToString()
        {
            return "제품명 : " + name + ", 가격 : " + price +"원";
        }
    }
}
