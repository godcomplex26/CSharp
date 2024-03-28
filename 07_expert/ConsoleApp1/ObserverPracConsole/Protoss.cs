using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPracConsole
{
    public class Protoss : ISubject
    {
        // 탈다림, 정화자, 이한리, 네라짐, 칼라이
        public string name {  get; set; }
        private List<IObserver> observers = new List<IObserver>();

        public void notify(string msg)
        {
            foreach (var item in observers)
            {
                item.update(msg);
            }
        }

        public void register(IObserver o)
        {
            observers.Add(o);
        }

        public void unregister(IObserver o)
        {
            observers.Remove(o);
        }
    }
}
