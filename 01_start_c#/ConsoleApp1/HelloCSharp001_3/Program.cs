using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inch -> cm
            Console.WriteLine("인치를 입력해 보세요.");
            double inch = double.Parse(Console.ReadLine());
            double cm = inch * 2.54;
            Console.WriteLine(inch + "인치는 " + cm + "cm 입니다.");
            Console.WriteLine();

            // kg -> 파운드
            Console.WriteLine("kg을 입력해 보세요.");
            double kg = double.Parse(Console.ReadLine());
            double pound = kg * 2.20462262;
            Console.WriteLine(kg + "kg은 " + pound + "파운드 입니다.");
            Console.WriteLine();

            // 반지름 -> 둘레, 넓이
            Console.WriteLine("반지름 입력해 보세요.");
            double rad = double.Parse(Console.ReadLine());
            double pi = 3.14;
            double cir = 2 * pi * rad;
            double area = pi * rad * rad;
            Console.WriteLine("반지름이 " + rad + "인 원 둘레는 " + cir + "입니다.");
            Console.WriteLine("반지름이 " + rad + "인 원 넓이는 " + area + "입니다.");
        }
    }
}
