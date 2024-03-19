using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = rnd.Next(6) + 1;

            switch (num)
            {
                case 1:
                case 2:
                    Console.WriteLine("1 아님 2 나옴");
                    break;
                case 3:
                    Console.WriteLine("3이 나옴");
                    break;
                case 4: // C#에서는 case 밑에 코드가 1줄이라도 있으면 break;
                    Console.WriteLine("4가 나옴"); // java는 break 없어도 돌아는 감. 밑에꺼 다 실행
                    break ;
                case 5:
                case 6:
                    Console.WriteLine("5~6");
                    break;
            }

        }
    }
}
