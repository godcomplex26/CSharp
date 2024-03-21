using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Dog : Animal // Animal을 상속 받음
    {
        public string hairColor { get; set; }

        public void Bark()
        {
            Fight(); // Animal을 상속 받았으므로 사용 가능
            Console.WriteLine("멍멍 짖는다.");
            // Run(); // Animal 안에서만 호출 됨
        }

        public void Eat() // new 쓰라고 경고, 안 써도 자동으로 적용되긴 함
        {
            Console.WriteLine("개처럼 먹는다.");
        }

        // overriding
        public override void Charm()
        {
            // base.Charm(); // 조상 클래스에 있는 Charm
            Console.WriteLine("주인님 ㅎㅎㅎ");
        }

        // hiding
        public new void Cry()
        {
            Console.WriteLine("아우우우우");
        }
    }
}
