using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 연도를 입력 받아서 띠 출력
            Console.WriteLine("태어난 년도를 입력 하세요.");
            int year = int.Parse(Console.ReadLine());
            int zSign = year % 12;

            if (zSign == 0)
            {
                Console.WriteLine("당신은 원숭이띠 입니다.");
            }
            else if (zSign == 1)
            {
                Console.WriteLine("당신은 닭띠 입니다.");
            }
            else if (zSign == 2)
            {
                Console.WriteLine("당신은 개띠 입니다.");
            }
            else if (zSign == 3)
            {
                Console.WriteLine("당신은 돼지띠 입니다.");
            }
            else if (zSign == 4)
            {
                Console.WriteLine("당신은 쥐띠 입니다.");
            }
            else if (zSign == 5)
            {
                Console.WriteLine("당신은 소띠 입니다.");
            }
            else if (zSign == 6)
            {
                Console.WriteLine("당신은 호랑이띠 입니다.");
            }
            else if (zSign == 7)
            {
                Console.WriteLine("당신은 토끼띠 입니다.");
            }
            else if (zSign == 8)
            {
                Console.WriteLine("당신은 용띠 입니다.");
            }
            else if (zSign == 9)
            {
                Console.WriteLine("당신은 뱀띠 입니다.");
            }
            else if (zSign == 10)
            {
                Console.WriteLine("당신은 말띠 입니다.");
            }
            else if (zSign == 11)
            {
                Console.WriteLine("당신은 양띠 입니다.");
            }

            // 현재 연도에 맞는 띠 출력
            int currentYear = DateTime.Now.Year;
            switch (currentYear % 12)
            {
                case 0:
                    Console.WriteLine("올해는 원숭이띠 입니다.");
                    break;
                case 1:
                    Console.WriteLine("올해는 닭띠 입니다.");
                    break;
                case 2:
                    Console.WriteLine("올해는 개띠 입니다.");
                    break;
                case 3:
                    Console.WriteLine("올해는 돼지띠 입니다.");
                    break;
                case 4:
                    Console.WriteLine("올해는 쥐띠 입니다.");
                    break;
                case 5:
                    Console.WriteLine("올해는 소띠 입니다.");
                    break;
                case 6:
                    Console.WriteLine("올해는 호랑이띠 입니다.");
                    break;
                case 7:
                    Console.WriteLine("올해는 토끼띠 입니다.");
                    break;
                case 8:
                    Console.WriteLine("올해는 용띠 입니다.");
                    break;
                case 9:
                    Console.WriteLine("올해는 뱀띠 입니다.");
                    break;
                case 10:
                    Console.WriteLine("올해는 말띠 입니다.");
                    break;
                case 11:
                    Console.WriteLine("올해는 양띠 입니다.");
                    break;
            }
            Console.WriteLine();

            // 월 입력 받아서 계절 출력
            Console.WriteLine("현재 월 입력 하세요.");
            int month = int.Parse(Console.ReadLine());
            if (month == 12 || month == 1 || month == 2)
            {
                Console.WriteLine("겨울 입니다.");
            }
            else if (month == 3 || month == 4 || month == 5)
            {
                Console.WriteLine("봄 입니다.");
            }
            else if (month == 6 || month == 7 || month == 8)
            {
                Console.WriteLine("여름 입니다.");
            }
            else if (month == 9 || month == 10 || month == 11)
            {
                Console.WriteLine("가을 입니다.");
            }

            // 현재 월에 맞는 계절 출력
            int currentMonth = DateTime.Now.Month;
            switch (currentMonth)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("겨울 입니다.");
                    break;
                case 3:
                case 4:
                case 5:
                    Console.WriteLine("봄 입니다.");
                    break;
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("여름 입니다.");
                    break;
                case 9:
                case 10:
                case 11:
                    Console.WriteLine("가을 입니다.");
                    break;
            }
        }
    }
}
