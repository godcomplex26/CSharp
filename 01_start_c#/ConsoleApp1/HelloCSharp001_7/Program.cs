using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelloCSharp001_7
{
    internal class Program
    {
        static void Main()
        {
            int[] num1 = new int[1000]; // cycle에서 검증할 숫자를 담는 배열
            int[] num2 = new int[1000]; // 카운트한 숫자의 종류와 카운트를 담는 배열(temp 느낌) -> 다음 cycle의 num1[]이 될 운명

            num1[0] = 1; // 1행은 1

            Console.Write("몇 번째까지 수행할지 입력하세요.");
            int cycle = int.Parse(Console.ReadLine());
            Console.WriteLine("1번째 수열 : 1");
            int count = 1;

            // 1번째는 1이니까 건너뛰고, 2번째 부터 수행하므로 총 cycle - 1 까지만 수행
            for (int i = 0; i < cycle - 1; i++)
            {
                int j = 0; // num1[]을 반복할 때 사용
                int k = 0; // num2[]에 커서 옮길 때 사용

                while (num1[j] != 0) // 0되면 빈칸(int[]를 1000개로 했기 때문에 입력받지 않은 빈칸은 0으로 자동 입력) 즉, 숫자 끝
                {
                    if (num1[j] == num1[j + 1]) // 전, 후 숫자가 같으면 그대로 숫자 카운트
                    {
                        count++;
                    }
                    else if (num1[j] != num1[j + 1]) // 전, 후 숫자가 다르면
                    {
                        num2[k] = num1[j]; // 현재 숫자(방금 카운트한 숫자의 종류)를 num2[k]에 담아두고
                        num2[k + 1] = count; // 이제껏 카운트를 num2[k+1]에 저장
                        k += 2; // k를 2 증가 -> 다음 카운트를 저장할 위치로 커서 전진
                        count = 1; // 카운트 초기화
                    }

                    j++; // 다음 숫자 진행
                }

                // num2 배열의 요소를 num1 배열로 복사, num2 배열의 길이만큼
                Array.Copy(num2, num1, num2.Length);
                Console.Write((i+2) + "번째 수열 : ");

                for (int n = 0; num1[n] != 0; n++) // 0 나오면 빈칸이니까 빈칸 전 까지만 출력
                {
                    Console.Write(num1[n]);
                }
                Console.WriteLine();
            }
        }
    }
}
