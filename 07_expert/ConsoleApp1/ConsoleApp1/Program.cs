using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        delegate void voidFunc(); // 반환형과 매개변수가 없는 메서드를 변수 형태로 저장하는 자료형

        static void testMethod()
        {
            Console.WriteLine("test~~~");
        }

        static void doFunc(voidFunc v, int count)
        {
            for (int i = 0; i < count; i++)
            {
                v();
            }
        }
        static void Main(string[] args)
        {
            testMethod();
            doFunc(testMethod, 3); // testMethod를 3번 호출
            doFunc(delegate () { Console.WriteLine("~~~"); }, 3); // 무명 델리게이트
            doFunc(() => { Console.WriteLine("@@@"); }, 3); // 람다식

            voidFunc v1 = delegate () { Console.WriteLine("안뇽~"); };
            voidFunc v2 = () => { Console.WriteLine("ㅎㅇ~"); };

            doFunc(v1, 5);
            doFunc(v2, 5);
        }
    }
}
