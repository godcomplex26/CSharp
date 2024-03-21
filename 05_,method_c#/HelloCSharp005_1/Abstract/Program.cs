using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Food f = new Food();
            Food f1 = new Gimbab();
            Food f2 = new Nahn();
            Gimbab g1 = new Gimbab();
            Nahn n1 = new Nahn();

            f1.taste();
            f2.taste();
            g1.taste();
            n1.taste();
        }
    }
}
