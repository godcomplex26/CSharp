using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Venusaur : Bulbasaur
    {
        public override void cry()
        {
            Console.WriteLine("흑흑");
        }

        public override void fight()
        {
            Console.WriteLine("퍽퍽");
        }

        public override void photosynthesis()
        {
            Console.WriteLine("반짝");
        }

        public override void blooming()
        {
            Console.WriteLine("활짝");
        }

        public override void bearFruit()
        {
            Console.WriteLine("주렁주렁");
        }
    }
}
