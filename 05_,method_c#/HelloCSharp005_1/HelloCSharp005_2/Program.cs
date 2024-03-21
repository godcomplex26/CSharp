using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloCSharp005_2
{
    internal class Program
    {
        // 메서드를 통해서 값 복사할 때는 ref를 넣자
        // ref를 안 넣으면 main의 원본에 영향을 줄 수가 없다.
        static void Change(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static void Main(string[] args)
        {
            int a = 3;
            int b = 5;

            Console.WriteLine(a); // 3
            Console.WriteLine(b); // 5

            int temp = a;
            a = b;
            b = temp;    

            Console.WriteLine(a); // 5
            Console.WriteLine(b); // 3

            Change(ref a, ref b);

            Console.WriteLine(a); // 3
            Console.WriteLine(b); // 5
        }
    }
}
