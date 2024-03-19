using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections; // ArrayList 활용

namespace HelloCSharp001_7_3
{
    internal class Program
    {
        static void Main()
        {
            ArrayList num1 = new ArrayList(); // cycle에서 검증할 숫자를 담는 리스트
            ArrayList num2 = new ArrayList(); // 검증이 끝날 동안 카운트한 숫자의 종류와 카운트를 담는 리스트(temp 느낌) -> 다음 cycle의 num1이 될 운명

            num1.Add(1); // 1행은 1

            Console.Write("몇 번째까지 수행할지 입력하세요.");
            int cycle = int.Parse(Console.ReadLine());
            Console.WriteLine("1번째 수열 : 1");
            int count = 1;

            // 1번째는 1이니까 건너뛰고, 2번째 부터 수행하므로 총 cycle - 1 까지만 수행
            for (int i = 0; i < cycle - 1; i++)
            {
                int j = 0; // num1을 반복할 때 사용

                while (j < num1.Count) // num1의 길이만큼 반복
                {
                    if (j < num1.Count - 1 && (int)num1[j] == (int)num1[j + 1]) // 전, 후 숫자가 같으면 그대로 숫자 카운트
                        // 마지막 숫자는 검증하지 않고 바로 else로 넘어가면 된다.(오히려 검증을 하려하면 [j+1]이 exception을 발생 시킨다.)
                        // 마지막 직전 숫자를 검증하면서 직전과 같았다면 직전 숫자에 count++이 반영되므로 그대로 출력하면 되고
                        // 직전과 다르다면 else로 넘어가면 되기 때문
                    {
                        count++;
                    }
                    else // 전, 후 숫자가 다르면
                    {
                        num2.Add(num1[j]); // 현재 숫자(방금 카운트한 숫자의 종류)를 num2에 추가
                        num2.Add(count); // 이제까지 카운트를 num2에 추가
                        count = 1; // 카운트 초기화
                    }

                    j++; // 다음 숫자 진행
                }

                num1.Clear(); // num1 비우기

                // num2의 요소를 num1로 복사
                foreach (int num in num2)
                {
                    num1.Add(num);
                }

                num2.Clear(); // num2 비우기

                Console.Write((i + 2) + "번째 수열 : ");

                foreach (var num in num1) // num1 출력
                {
                    Console.Write(num);
                }
                Console.WriteLine();
            }
        }
    }
}
