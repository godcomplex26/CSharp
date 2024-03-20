using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp001_7_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String start = "1";
            int limit = 20;
            for(int i = 0; i < limit; i++) 
            {
                Console.WriteLine(i+1 + "번째 수열 : " + start);
                char num = start[0]; // 읽은 숫자
                String end = ""; // 읽고 말하기 누적용 변수
                int count = 0; // 읽은 숫자의 개수
                for (int j = 0; j < start.Length; j++)
                {
                    if (start[j] == num)
                    {
                        count++;
                    }
                    else
                    {
                        end = end + num + count;
                        num = start[j];
                        count = 1;
                    }
                }
                    end = end + num + count;
                    start = end;
            }
        }
    }
}
