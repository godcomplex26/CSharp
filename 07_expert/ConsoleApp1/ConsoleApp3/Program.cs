using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "고구마", Price = 1000 });
            products.Add(new Product { Name = "감자", Price = 700 });
            products.Add(new Product { Name = "파", Price = 800 });

            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + products[i].Price);
            }

            Console.WriteLine("delegate 활용 정렬");

            // delegate 활용 정렬
            products.Sort(delegate (Product a, Product b)
            {
                return a.Price.CompareTo(b.Price);
            });

            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + products[i].Price);
            }

            products.Clear();
            Console.WriteLine("------------------------------");

            products.Add(new Product { Name = "고구마", Price = 1000 });
            products.Add(new Product { Name = "감자", Price = 700 });
            products.Add(new Product { Name = "파", Price = 800 });

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + products[i].Price);
            }

            Console.WriteLine("람다 활용 정렬");

            // 람다 활용 정렬
            products.Sort((a, b) =>
            {
                return a.Price.CompareTo((b.Price));
            });

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].Name + products[i].Price);
            }
        }
    }
}
