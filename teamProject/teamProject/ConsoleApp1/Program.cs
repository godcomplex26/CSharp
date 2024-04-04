using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = 2.99;
            string roundedNumberString = number.ToString("0.0"); // 소수점 이하 첫째 자리까지 표시됨

            double roundedNumber = double.Parse(roundedNumberString);
            Console.WriteLine(roundedNumber); // 출력: 2.9
            Console.WriteLine(double.Parse("2.99"));
        }
    }
}
