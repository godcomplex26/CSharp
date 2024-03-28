using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPracConsole
{
    public interface IObserver // 관찰자의 역핳 정의
    {
        void update(string value);
    }
}
