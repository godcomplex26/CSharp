using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Student
    {
        // datagridview 바인딩 하기 전 반드시 해야할 것 ( 둘 중 하나 )
        // 1. 한 번 실행하고 나서 바인딩 한다.
        // 2. 빌드 -> 솔루션 정리, 빌드 다시 누르고 바인딩 한다.

        public string hakbeon {  get; set; } // 이거 2개만 나옴
        public string name { get; set; } // 이거 2개만 나옴
        public int age; // 이건 datagridview에 안나옴
    }
}
