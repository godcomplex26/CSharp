using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IPocketmon
    {
        int age { get; set; } // 포켓몬이라면 나이를 가지고 있음, 대신 이게 인터페이스에 들어가면 이 get과 set도 구현해야 함

        string ability { get; set; }

        void fight();

        void charming();

    }
}
