using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        // 반환형이 없고 매개변수가 Product 인 개인 자료형
        delegate void printProduct(Product p);

        static void printObject(printProduct pp, Product p, int count)
        {
            for(int i = 0; i < count; i++)
            {
                pp(p);
            }
        }

        static void myproductinfo(Product p)
        {
            Console.WriteLine("제품명 : " + p.Name);
            Console.WriteLine("제품가격 : " + p.Price);
        }

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

            printObject(myproductinfo, products[0], 5);
            printObject(delegate (Product p)
            {
                Console.WriteLine("이름 : " + p.Name + ", " + p.Price +"원");
            }, products[0], 5);
            printObject(p => { Console.WriteLine("이름 : " + p.Name + ", " + p.Price + "원"); }, products[0], 5);

            printProduct myp = myproductinfo;
            myp = delegate (Product p)
            {
                Console.WriteLine("이름 : " + p.Name + ", " + p.Price + "원");
            };
            myp = p =>
            {
                Console.WriteLine("이름 : " + p.Name + ", " + p.Price + "원");
            };
            printObject(myp, products[0], 3);
            }
    }
}
