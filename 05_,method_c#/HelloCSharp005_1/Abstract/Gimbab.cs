using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public class Gimbab : Food
    {
        public override void taste() // abstract에 있는 abstract 메서드를 override 해야 한다.
        {
            Console.WriteLine("젓가락 이용해서 먹습니다.");
        }
    }
}
