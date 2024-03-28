using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPrac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int test = MyMath.getInstance().power(5);
            Console.WriteLine(test);

            MyMath m = MyMath.getInstance();

            Console.WriteLine(m.plus(3,5));
            Console.WriteLine(m.minus(5,3));
        }
    }
}
