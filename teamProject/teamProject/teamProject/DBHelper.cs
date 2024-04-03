using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teamProject
{
    public abstract class DBHelper
    {
        protected SqlConnection conn = new SqlConnection();
        protected SqlDataAdapter da;
        protected DataSet ds;
        public DataTable dt;

        protected abstract void ConnectDB();

        public abstract void DoQueryR(string c1 = "-1", string c2 = "-1", string c3 = "-1"); // select 용
        public abstract void DoQueryR2(string c1 = "-1", string c2 = "-1", string c3 = "-1"); // select 용

        public abstract void DoQueryC(PData data); // insert용
        public abstract void DoQueryD(PData data); // delete 용
    }
}
