using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    // 추상 클래스인 Animal을 상속 -> 추상 메서드 반드시 구현해야 할 의무 부여
    public class Dog : Animal
    {
        public override void sleep()
        {
            Console.WriteLine("멍멍멍");
        }

        public override void eat()
        {
            Console.WriteLine("촵촵촵");
        }

        public override void cry()
        {
            Console.WriteLine("zZzZ....");
        }
    }
}
