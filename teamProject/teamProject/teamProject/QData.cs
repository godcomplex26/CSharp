using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    public class QData
    {
        public DateTime date { get; set; } // PK
        public int weight { get; set; }
        public double water { get; set; }
        public double material { get; set; }
        public int HSO { get; set; }
        public double pH { get; set; }
    }
}
