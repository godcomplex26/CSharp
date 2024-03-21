using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMath
{
    public class MyMath
    {
        private int input { get; set; }
        private int count { get; set; }
        private int start { get; set; }
        private int end { get; set; }

        public MyMath(int input, int count, int start, int end)
        {
            this.input = input;
            this.count = count;
            this.start = start;
            this.end = end;
        }
        // 인스턴스 메서드
        public int Power()
        {
            return input * input;
        }

        // 인스턴스 메서드
        public int Power2()
        {
            int result = 1;

            for (int i = 0; i < count; i++)
            {
                result *= input;
            }
            return result;
        }

        // 인스턴스 메서드
        public int SumAll()
        {
            int result = 0;

            for (int i = 0; i < end + 1; i++)
            {
                result += i;
            }
            return result;
        }

        // 인스턴스 메서드
        public int SumAll2()
        {
            int result = 0;

            for (int i = start; i < end + 1; i++)
            {
                result += i;
            }
            return result;
        }
    }
}
