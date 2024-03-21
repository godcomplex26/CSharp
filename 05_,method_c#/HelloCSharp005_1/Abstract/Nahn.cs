using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public class Nahn : Food
    {
        public override void taste()
        {
            Console.WriteLine("깨끗하게 씻은 오른손으로 먹습니다.");
        }
    }
}
