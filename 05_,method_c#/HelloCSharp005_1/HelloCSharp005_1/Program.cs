using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloCSharp005_1
{
    internal class Program
    {
        static void change(int input)
        {
            input++;
        }
        static void Main(string[] args)
        {
            int a = 10;
            int b = a;
            b = 20;
            Console.WriteLine("a=" + a + ", b=" + b); // 서로 영향 x -> 파일을 복사 붙여넣기 한 것
            change(a);
            Console.WriteLine("a=" + a);

            Student s = new Student();
            s.name = "이종운";
            s.age = 30;
            s.score = 100;

            Student dj = s; // new 로 복사를 안하고, 그냥 이렇게 해버리면 -> 바로가기를 만든 것
            // dj와 s가 똑같은 주소를 가지게 되므로
            // dj를 바꾸면 그 주소의 메모리가 바뀌므로
            // s가 가리키는 메모리도 같은 주소의 메모리가 조회
            dj.score = 0;
            dj.name = "이동준";

            Console.WriteLine(s.name + ", " + s.age + ", " + s.score);
            Console.WriteLine(dj.name + ", " + dj.age + ", " + dj.score);
        }
    }
}
