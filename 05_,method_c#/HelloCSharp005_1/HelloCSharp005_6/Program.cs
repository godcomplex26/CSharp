using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 제네릭 활용 예시
            Student<int> s1 = new Student<int>();
            Student<String> s2 = new Student<String>();

            s1.hakbeon = int.Parse("0123");
            s2.hakbeon = "0123";

            Console.WriteLine("s1의 학번 : " +  s1.hakbeon); // 123
            Console.WriteLine("s2의 학번 : " +  s2.hakbeon); // 0123

            /*            int a = int.Parse("aaa");
                        Console.WriteLine("프로그램이 튕기므로 이 부분 실행 안 됨");
            */

            // TryParse는 Parse를 시도해서 되면 하고
            // 안 되면 false값을 반환
            int a;
            int.TryParse("aaa", out a);
            int.TryParse("aaa", out int b);
            bool fa = int.TryParse("aaa", out a);
            bool fb = int.TryParse("aaa", out b);
            Console.WriteLine("a = " + a + ", b = " + b);
            Console.WriteLine("fa = " + fa + ", fb = " + fb);
        }
    }
}
