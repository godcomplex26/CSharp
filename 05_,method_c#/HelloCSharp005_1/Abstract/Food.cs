using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    // Food 만으로는 인스턴스를 못 만든다.
    // 구체화가 불가능 하다.
    // Food f = new Food() 가 불가능 하다.
    public abstract class Food // 추상화된 클래스
    {
        public string name { get; set; }
        public int price { get; set; }

        public abstract void taste(); // 시식을 추상화
        // Food 를 상속받은 클래스에서 이 메서드를 구체화 해야 한다.
        // 음식마다 시식하는 방법은 다 다르기 때문이다.
    }
}
