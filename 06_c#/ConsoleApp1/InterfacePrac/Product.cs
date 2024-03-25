using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePrac
{
    public class Product : IComparable
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return "제품 : " + Name + ", 가격 : " + Price + "원";
        }

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo(((Product)obj).Price);
        }
    }
}
