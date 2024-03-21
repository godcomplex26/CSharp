using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{
    internal class Program
    {
        // 클래스 메서드
        static int Power(int input)
        {
            return input * input;
        }

        // 클래스 메서드
        static int Power(int input, int count)
        {
            int result = 1;

            for(int i = 0; i < count; i++)
            {
                result *= input;
            }
            return result;
        }

        // 클래스 메서드
        static int SumAll(int end)
        {
            int result = 0;

            for(int i = 0; i < end + 1; i++)
            {
                result += i;
            }
            return result;
        }

        // 클래스 메서드
        static int SumAll(int start, int end)
        {
            int result = 0;

            for (int i = start; i < end + 1; i++)
            {
                result += i;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Power(2));
            Console.WriteLine(Power(2, 3));
            Console.WriteLine(SumAll(10));
            Console.WriteLine(SumAll(2, 10));

            MyMath m = new MyMath(2, 3, 2, 10);
            Console.WriteLine(m.Power());
            Console.WriteLine(m.Power2());
            Console.WriteLine(m.SumAll());
            Console.WriteLine(m.SumAll2());
        }
    }
}
