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

        // 클래스 말고, 배열이나 List도 똑같이 참조 복사 개념 동일함
        // 구조체 Struct는 일반 자료형 처럼 값 복사 개념 적용
        static void change(Student student)
        {
            student.name = "김길동";
            student.age = 20;
            student.score = 90;
        }

        // ref = 참조자
        // 메서드 안에서 값이 바뀌면 원본도 같이 바뀜
        static void change(ref int input)
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
            Console.WriteLine("a=" + a); // 10
            change(ref a);
            Console.WriteLine("a=" + a); // 11

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

            Student s2 = new Student(); // 제대로 복사 된 것
            s2.name = "홍길동";
            s2.age = s.age;
            s2.score = 80;

            Console.WriteLine(s2.age);
            s2.age = 40; // 값 복사라서 영향 x
            Console.WriteLine(s.age); // 30
            Console.WriteLine(s2.age); // 40

            change(s2); // 김길동으로 바뀐다
            Console.WriteLine(s2.name + ", " + s2.age + ", " + s2.score);
        }
    }
}
