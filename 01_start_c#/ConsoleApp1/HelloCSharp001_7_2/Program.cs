using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_7_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 별 피라미드
            Console.WriteLine("원하는 층수를 입력하세요.");
            int floor = int.Parse(Console.ReadLine());
            for(int i = 0; i < floor; i++) // i = 현재 층수, 위에서 부터 늘려나간다
            {
                // 공백 찍는 부분(공백 : 위에서부터 총 층수 - 현재 층수개, 위에서 부터 줄여나간다)
                for(int j = 0; j < floor - i; j++) // for(int j = floor - i; j > 1; j--)
                {
                    Console.Write(" ");
                }
                
                // 별 찍는 부분(별 : 위에서부터 2 * 현재 층수 + 1 개, 위에서 부터 늘려나간다)
                for(int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");   
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // 5개의 숫자를 입력받은 뒤 가장 작은 수와 가장 큰 수를 출력하는 프로그램1
            int[] nums = new int[5];
            for(int i = 0; i < nums.Length; i++)
            {
                Console.Write((i+1) + "번째 숫자를 입력하세요.");
                nums[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("입력 받은 값 : ");
            for(int i =0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();

            // 버블정렬
            for (int i = 0; i < nums.Length - 1; i++) // 전체 크기 - 1 만큼 수행
            {
                for (int j = 0; j < nums.Length - i - 1; j++) // 정렬 대상 끝부터 하나씩 줄여나감
                {
                    if (nums[j] > nums[j + 1]) // 앞 번호가 크면
                    {
                        // 전, 후 변경 arr[j] and arr[j+1]
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("가장 작은 값 : " + nums[0]); // 가장 작은 값(0번 값)
            Console.WriteLine("가장 큰 값 : " + nums[nums.Length - 1]); // 가장 큰 값(끝 값)
            Console.WriteLine();

            // 5개의 숫자를 입력받은 뒤 가장 작은 수와 가장 큰 수를 출력하는 프로그램2
            int[] nums2 = new int[5];
            for (int i = 0; i < nums2.Length; i++)
            {
                Console.Write((i + 1) + "번째 숫자를 입력하세요.");
                nums2[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("입력 받은 값 : ");
            for (int i = 0; i < nums2.Length; i++)
            {
                Console.Write(nums2[i] + " ");
            }
            Console.WriteLine();

            // max, min을 지정하여 반복 후 max, min을 출력
            int max = nums2[0];
            int min = nums2[0];
            for(int i = 1; i < nums2.Length; ++i)
            {
                if(max < nums2[i])
                {
                    max = nums2[i];
                }
                if(min > nums2[i])
                { 
                    min = nums2[i]; 
                }
            }
            Console.WriteLine("가장 작은 값: " + min); // 가장 작은 값
            Console.WriteLine("가장 큰 값: " + max); // 가장 큰 값

        }
    }
}
