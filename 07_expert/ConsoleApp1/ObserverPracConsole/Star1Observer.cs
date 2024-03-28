using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPracConsole
{
    public class Star1Observer : IObserver
    {
        public void update(string value)
        {
            Console.WriteLine("--- 항상 움직일 수 있고 클로킹 상태임 ---");
            Console.WriteLine("스타1 옵저버 관찰 결과 : " + value);
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@");
        }
    }
}
