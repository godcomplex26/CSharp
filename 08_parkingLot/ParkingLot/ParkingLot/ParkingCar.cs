using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    // internal class는 외부 호출할 때 일관성 없는 엑세스 가능성 오류 뜬다
    // public으로 잘 바꿔주기
    public class ParkingCar
    {
        public string parkingspot { get; set; } // PK
        public string carnumber { get; set; }
        public string drivername { get; set; }
        public string phonenumber { get; set; }
        public DateTime parkingtime { get; set; }

    }
}
