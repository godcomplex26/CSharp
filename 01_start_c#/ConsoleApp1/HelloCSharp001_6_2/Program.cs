using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for(int i = 0; i <= 100; i++) { // 지역 변수 i는 끝나고 메모리에서 사라진다.
                sum += i;
            }
            Console.WriteLine("1부터 100까지의 합 : " + sum);

            int[] nums = { 11, 10, 50, 27, 30 };
            // nums라는 배열 안에 있는 값들을 하나씩 item에 집어넣어서
            // nums의 길이만큼 반복문을 수행
            // foreach(var 요소 in 컬렉션 {}
            // 컬렉션 = 배열이나 List와 같은 여러 개의 값을 저장하는 것
            // java의 for(int i : nums) {} 와 동일
            foreach(var item in nums)
            {
                Console.WriteLine(item);
            }

            // goto문 : 어중간하게 쓰지마라. 코드 꼬인다^^
            StartPos:
            Console.WriteLine("숫자 입력");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if(num < 0)
            {
                goto StartPos;
            }
            Console.WriteLine("프로그램 종료");
        }
    }
}
