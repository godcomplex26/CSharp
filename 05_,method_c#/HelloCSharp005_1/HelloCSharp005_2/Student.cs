using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp005_2
{
    public struct Student // 구조체 != 클래스
        // 복사하는 방식이 값 복사 방식을 쓴다.
    {
        public string name { get; set; }
        public int age { get; set; }

        public int score { get; set; }
    }
}
