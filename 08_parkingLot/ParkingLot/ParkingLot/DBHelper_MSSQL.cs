using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    // 다른 DBMS를 사용할 가능성을 열어두는 것
    public class DBHelper_MSSQL : DBHelper
    {
        // 싱글톤 적용
        // 얘를 계속 돌려씀
        private static DBHelper_MSSQL instance;
        public static DBHelper_MSSQL getInstance
        {
            get
            {
                if (instance == null) // 없으면 인스턴스 하나 만들고
                {
                    instance = new DBHelper_MSSQL();
                }
                return instance; // 있으면 계속 재활용
            }
        }
        private DBHelper_MSSQL() { } // 외부에서 인스턴스 못 만들게

        protected override void ConnectDB()
        {
            conn.ConnectionString = $"Data Source=({"local"}); " +
                $"Initial Catalog = {"ProjectDataBase"}; Integrated Security = {"SSPI"}; Timeout={3}";
            conn = new SqlConnection(conn.ConnectionString);
            conn.Open();
        }

        // DoQuery() // ps 값은 자동으로 "-1"을 대입
        // DoQuery("123") // ps 값을 "123"을 대입함
        // 즉, 기본값 설정하는 방법
        public override void DoQuery(string ps = "-1") // select 전체 or 특정 공간 정보
        {
           try
            { 
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (ps.Equals("-1")) // 매개 변수 없는 경우
                {
                    cmd.CommandText = "select * from parkingLot";
                }
                else
                {
                    cmd.CommandText = "select * from parkingLot where parkingspot=@parkingspot";
                    cmd.Parameters.AddWithValue("@parkingspot", ps);
                }
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "parkingLot");
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);
                DataManager.PrintLog(ex.Message);
                DataManager.PrintLog(ex.StackTrace);
            }
            finally 
            { 
                conn.Close();
            }
         }

        public override void DoQuery(ParkingCar car)
        {
            try
            {
                ConnectDB();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sql = "";
                sql = "update parkingLot set carnumber=@carnumber, drivername=@drivername, phonenumber=@phonenumber, parkingTime=@parkingTime where parkingspot=@parkingspot";
                cmd.Parameters.AddWithValue("@carnumber", car.carnumber);
                cmd.Parameters.AddWithValue("@drivername", car.drivername);
                cmd.Parameters.AddWithValue("@phonenumber", car.phonenumber);
                cmd.Parameters.AddWithValue("@parkingtime", car.parkingtime);
                cmd.Parameters.AddWithValue("@parkingspot", car.parkingspot);

                if (car.carnumber == "") // 출차 시
                {
                    sql = "update parkingLot set carnumber=@carnumber," +
                        "drivername=@drivername,phonenumber=@phonenumber," +
                        "parkingtime='' where parkingspot=@parkingspot";
                    cmd.Parameters.RemoveAt(3);  // @parkingtime 삭제
                }

                cmd.CommandText= sql;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);
                DataManager.PrintLog(ex.Message);
                DataManager.PrintLog(ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        // 주차 공간 추가 및 삭제 코드
        private void spotManagingQuery(string ps, string cmd)
        {
            string sql = "";
            cmd = cmd.ToLower();
            if (cmd.Equals("insert"))
            {
                sql = "insert into parkingLot(parkingspot) values(@ps)";
            }
            else
            {
                sql = "delete from parkingLot where parkingspot = @ps";
            }

            try
            {
                ConnectDB();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.Parameters.AddWithValue("@ps", ps);
                sqlCommand.CommandText = sql;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);
                DataManager.PrintLog(ex.Message);
                DataManager.PrintLog(ex.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        public void deleteParkingSpot(string ps)
        {
            spotManagingQuery(ps, "delete");
        }

        public void insertParkingSpot(string ps)
        {
            spotManagingQuery(ps, "insert");
        }
        
    }
}
