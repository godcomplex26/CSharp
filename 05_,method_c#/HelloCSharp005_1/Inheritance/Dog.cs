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
    }
}
