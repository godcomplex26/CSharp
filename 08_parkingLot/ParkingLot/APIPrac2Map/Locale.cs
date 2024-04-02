using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPrac2Map
{
    public class Locale
    {
        public string name {  get; set; }
        public double Lat {  get; set; } // Y 좌표 의미함
        public double Lng { get; set; } // X 좌표 의미함

        // 빈 곳에 alt+enter 하면 생성자 생성 나옴
        public Locale(string name, double lat, double lng)
        {
            this.name= name;
            this.Lat = lat;
            this.Lng = lng;
        }

        public override string ToString()
        {
            return name; // name 값만 리턴
        }
    }
}
