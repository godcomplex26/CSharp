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
        }
    }
}
