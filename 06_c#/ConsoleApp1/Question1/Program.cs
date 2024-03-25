using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    internal class Program
    {
        // 메서드 중에만 바뀜
        public static void swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        // 바뀐 상태 유지
        public static void swapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        // out은 할당되기 전에는 다른 변수에 할당할 수 없다.
        public static void swapOut(int olda, int oldb, out int a, out int b)
        {
            a = olda;
            b = oldb;

            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        static void Main(string[] args)
        {
            int a = 3, b = 5;
            swap(a, b); // 5, 3, 메서드 할 때는 바뀌지만, 끝나면 다시 원상 복구
            Console.WriteLine(a); // 3 
            Console.WriteLine(b); // 5

            // 변수를 참조 형태로 메서드로 전달
            swapRef(ref a, ref b); // 5, 3, 메서드 할 때 바뀌어서, 끝나도 바뀐 상태 유지
            Console.WriteLine(a); // 5
            Console.WriteLine(b); // 3

            // 메서드 내에서 변수를 초기화
            swapOut(a, b, out a, out b); // 3, 5
            Console.WriteLine(a); // 3
            Console.WriteLine(b); // 5
        }
    }
}
