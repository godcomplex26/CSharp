using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };

            // 짝수만 가져오고 싶다.

            List<int> evenNum = new List<int>();
            foreach (var item in nums)
            {
                if (item % 2 == 0)
                {
                    evenNum.Add(item);
                }
            }

            // LINQ = 컬렉션(=배열이나 List)에 있는 값을 sql 형식으로 가져오는 문법
            // from 요소이름(=임의변수이름) in 컬렉션명 where 조건 select 가져올 값 [order by desc, asc];
            var evenNum2 = from item in nums where item % 2 == 0 select item;

            foreach (var item in evenNum)
            {
                Console.WriteLine(item);
            }

            foreach (var item in evenNum2)
            {
                Console.WriteLine(item);
            }

            List<int> powerNum = new List<int>();
            foreach (var item in nums)
            {
                powerNum.Add(item * item);
            }
            foreach (var item in powerNum)
            {
                Console.WriteLine(item);
            }

            var powerNum2 = from item in nums select item * item;
            foreach (var item in powerNum2)
            {
                Console.WriteLine(item);
            }

            List<int> myeven = evenNum2.ToList();
            List<int> mypower = powerNum2.ToList();

            List<int> oddNum = (from item in nums where item % 2 == 1 select item).ToList();
            foreach (var item in oddNum)
            {
                Console.WriteLine(item);
            }

            var powerEvenOutput = from item in nums
                                  where item % 2 == 0
                                  select new // 임의의 객체를 이용해서 컬렉션 형태로 가져오기도 가능
                                  {
                                      num = item,
                                      dubleNum = item * 2,
                                      powerNum = item * item
                                  };

            foreach (var item in powerEvenOutput)
            {
                Console.WriteLine(item.num + ", " + item.dubleNum + ", " + item.powerNum);
            }

            // linq의 장단점
            // 장점 : for와 if 없이 쉽게 값을 뽑아낼 수 있다.
            // 단점 : 이 코드가 모두 1줄로 간주되기 때문에 오류가 생기면 디버깅하기 너무 힘들다.

            List<Product> products = new List<Product>();
            products.Add(new Product { name = "고구마", price = 5000 });
            products.Add(new Product { name = "마", price = 2500 });
            products.Add(new Product { name = "당근", price = 9000 });
            products.Add(new Product { name = "파", price = 500 });
            products.Add(new Product { name = "감자", price = 5500 });

            var myproducts = from item in products where item.price > 5000 orderby item.name ascending select item;

            List<Product> vipProducts = (from item in products where item.price > 5000 orderby item.name ascending select item).ToList<Product>();

            foreach (var item in myproducts)
            {
                Console.WriteLine(item.ToString()); // 감자 당근
            }

            foreach (var item in vipProducts) // 감자 당근
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
