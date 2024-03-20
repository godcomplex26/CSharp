using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp002_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product();
            p1.name = "감자";
            p1.price = 1000;
            Product.countOfProduct++;

            Product p2 = new Product()
            {
                name = "당근",
                price = 500
             };
            Product.countOfProduct++;

            Console.WriteLine(p1.name);
            Console.WriteLine(p1.price);
            Console.WriteLine(p2.name);
            Console.WriteLine(p2.price);
            Console.WriteLine(Product.countOfProduct);
        }
    }
}
