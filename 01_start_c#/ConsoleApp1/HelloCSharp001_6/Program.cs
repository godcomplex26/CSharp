using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] zSigns = { "원숭이", "닭", "개", "돼지", "쥐", "소", "호랑이", "토끼", "용", "뱀", "말", "양" };
            // c#에서는 무조건 자료형 뒤에 []가 붙는다.
            // java는 변수명 뒤에 붙여도 된다.
            // int[] a / int a[], java는 둘 다 가능 / c#은 전자만

            Console.WriteLine("태어난 년도를 입력 하세요.");
            int year = int.Parse(Console.ReadLine());
            int zSign = year % 12;

            Console.WriteLine("당신은 " + zSigns[zSign] + "띠 입니다.");
            Console.WriteLine($"당신은 {zSigns[zSign]}띠 입니다.");

            String[] seasons = { "겨울", "겨울", "봄", "봄", "봄", "여름", "여름", "여름", "가을", "가을", "가을", "겨울" };
            Console.WriteLine("현재 월을 입력 하세요.");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("지금은 " + seasons[month - 1] + "입니다.");
        }
    }
}
