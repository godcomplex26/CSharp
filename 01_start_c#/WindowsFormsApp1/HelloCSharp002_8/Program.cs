using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp002_8
{
    internal class Program
    {
        // 오버로딩 : 매개변수의 개수나 타입 다르면
        // 함수(=메서드) 이름 똑같아도 서로 다른 것으로
        // java 와 동일
        static void introduce(int age)
        {
            Console.WriteLine("내 나이는 " + age + "입니다.");
        }

        static void introduce(string name)
        {
            Console.WriteLine("내 이름은 " + name + "입니다.");
        }

        static void introduce()
        {
            Console.WriteLine("자기 소개 메서드");
        }

        static void Main(string[] args)
        {
            introduce(30);
            introduce("이종운");
            introduce();
            Rectangle.color = "파란색";
            Rectangle rec1 = new Rectangle();
            rec1.width = 10;
            rec1.height = 5;
            Rectangle rec2 = new Rectangle();
            rec2.width = 7;
            rec2.height = 8;
            Rectangle rec3 = new Rectangle();

            Console.WriteLine(rec1.getArea());
            Console.WriteLine(rec2.getArea());
            Console.WriteLine(rec3.getArea());
            Console.WriteLine(Rectangle.calcRecArea(100,200));

            // Product p1 = new Product() // 불가능
            Product p1 = new Product("고구마", 500);
            Console.WriteLine(p1.name + "의 가격 : " + p1.price);
            Product p2 = new Product("대게");
        }
    }
}
