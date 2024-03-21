using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005_3
{
    internal class Program
    {
        static Dictionary<int, long> memo = new Dictionary<int, long>();
        static long Fibo(int i)
        {
            if (i <= 0)
            {
                return 0;
            }
            if (i == 1)
            {
                return 1;
            }
            return Fibo(i - 2) + Fibo(i - 1);
        }

        static long Fibo2(int i)
        {
            if (i <= 0)
            {
                return 0;
            }
            if (i == 1)
            {
                return 1;
            }
            if (memo.ContainsKey(i))
            {
                return memo[i];
            }
            else
            {
                long value = Fibo2(i - 2) + Fibo2(i - 1);
                memo[i] = value;
                return value;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("mm분ss초fff"));
            Fibo(100);
            Console.WriteLine(DateTime.Now.ToString("mm분ss초fff"));
            Fibo2(100);
            Console.WriteLine(DateTime.Now.ToString("mm분ss초fff"));
        }
    }
}
