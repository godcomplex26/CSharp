using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPracConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Star2Observer s2o1 = new Star2Observer();
            s2o1.isObserverMode = true; // 관측모드
            Star2Observer s2o2 = new Star2Observer();
            s2o2.isObserverMode = false; // 감시모드

            Star1Observer s1o1 = new Star1Observer();
            Star1Observer s1o2 = new Star1Observer();

            Protoss kalai = new Protoss(); // 스타1, 스타2에 다 등장
            kalai.name = "칼라이";
            Protoss nerazim = new Protoss(); // 스타2에만 등장
            nerazim.name = "네라짐";
            Protoss taldarim = new Protoss();
            taldarim.name = "탈다림";

            kalai.register(s1o1);
            kalai.register(s1o2);
            kalai.register(s2o1);
            kalai.register(s2o2);
            kalai.notify("적이 공격중입니다.");

            Console.WriteLine();
            Console.WriteLine();

            nerazim.register(s2o1);
            nerazim.register(s2o2);
            nerazim.notify("적이 공격중이다!!!");

            Console.WriteLine();
            Console.WriteLine();

            taldarim.register(s2o1);
            taldarim.register(s2o2);
            taldarim.unregister(s2o2); // 알라라크의 라크쉬르를 훔쳐보는 옵져버 하나 부서짐
            taldarim.notify("라크쉬르가 시작되었다!");

            // 옵저버 패턴은 일괄적으로 특정 인터페이스에 있는 메서드를 호출 가능하고
            // 일괄적으로 호출할 그룹에 특정 객체를 추가하거나 제외할 수 있는 것이다.
        }
    }
}
