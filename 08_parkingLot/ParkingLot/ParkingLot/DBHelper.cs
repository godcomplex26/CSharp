using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    // 다른 DBMS를 사용할 가능성을 열어두는 것
    public abstract class DBHelper
    {
        protected SqlConnection conn = new SqlConnection();
        protected SqlDataAdapter da;
        protected DataSet ds;
        public DataTable dt;

        protected abstract void ConnectDB();

        public abstract void DoQuery(String ps="-1"); // select 용

        // internal class는 외부 호출할 때 일관성 없는 엑세스 가능성 오류 뜬다
        // public으로 잘 바꿔주기
        public abstract void DoQuery(ParkingCar car); // insert, update, delete 용

    }
}
