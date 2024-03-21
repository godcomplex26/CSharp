using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("야옹");
        }

        public void Eat() // new 쓰라고 경고, 안 써도 자동으로 적용되긴 함
        {
            Console.WriteLine("쩝쩝 고양이스럽게 먹는다.");
        }

        // overriding
        public override void Charm()
        {
            // base.Charm(); // 조상 클래스에 있는 Charm
            Console.WriteLine("집사, 잘 했네. 쓰담쓰담");
        }

        // hiding
        public new void Cry()
        {
            Console.WriteLine("집사 ㅠㅠ 이럴 줄 몰랐어 ㅠㅠ");
        }
    }
}
