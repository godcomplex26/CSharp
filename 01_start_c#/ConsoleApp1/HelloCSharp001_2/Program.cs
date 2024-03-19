using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int double char String
            int a = 35;
            double b = 3.14;
            char c = 'A';
            String d = "이종운"; // string, String 차이 없음
            string d2 = "홍길동";
            Console.WriteLine(int.MaxValue); // 약 21억
            Console.WriteLine(int.MinValue);
            Console.WriteLine(long.MaxValue); // 약 922경
            Console.WriteLine(long.MinValue);
            Console.WriteLine("안녕하세요"[0]);
            Console.WriteLine("Text 입력해보세요");
            string text = Console.ReadLine();
            Console.WriteLine("정수 입력해보세요");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(num + num); // 숫자끼리 더하기
            Console.WriteLine(text + num); // 글자 이어 붙이기
        }
    }
}
