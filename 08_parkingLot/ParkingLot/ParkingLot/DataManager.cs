using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLot
{
    public class DataManager
    {
        public static List<ParkingCar> Cars = new List<ParkingCar>();

        // 앞으로 DB와의 연락은 mssql이 모두 수행
        private static DBHelper_MSSQL mssql = DBHelper_MSSQL.getInstance; // 싱글톤

        public DataManager()
        {
            Load();
        }

        public static void Load() // 전체 불러오기
        {
            try
            {
                mssql.DoQuery(); // 전체 조회
                Cars.Clear(); // Cars 초기화
                foreach (DataRow item in mssql.dt.Rows)
                {
                    ParkingCar car = new ParkingCar();
                    car.parkingspot = item["parkingspot"].ToString();
                    car.carnumber = item["carnumber"].ToString();
                    car.drivername = item["drivername"].ToString();
                    car.phonenumber = item["phonenumber"].ToString();
                    car.parkingtime = item["parkingtime"].ToString() == "" ? new DateTime() : DateTime.Parse(item["parkingtime"].ToString());
                    Cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                PrintLog(ex.StackTrace + "from Load");
            }
            finally
            {
                
            }
        }

        // contents = 로그 기록용
        public static bool Save(string cmd, string ps, out string contents) // 주차 공간 추가 삭제용 Save
        {
            contents = "";
            if (cmd.Equals("insert"))
            {
                return DBInsert(ps, ref contents);
            }
            else
            {
                return DBDelete(ps, ref contents);
            }
        }

        private static bool DBDelete(string ps, ref string contents)
        {
            if (mssql.dt.Rows.Count != 0)
            {
                mssql.deleteParkingSpot(ps);
                contents = $"주차공간 {ps}이/가 삭제";
                return true;
            }
            else // 주차 공간 없음
            {
                contents = "해당 공간 없음";
                return false;
            }
        }

        private static bool DBInsert(string ps, ref string contents)
        {
            if (mssql.dt.Rows.Count == 0)
            {
                mssql.insertParkingSpot(ps);
                contents = $"주차공간 {ps}이/가 추가";
                return true;
            }
            else
            {
                contents = "해당 공간 이미 없음";
                return false;
            }
        }

        public static void Save(ParkingCar car) // 주차 출차용
        {
            mssql.DoQuery(car);
        }

        public static void PrintLog(string contents)
        {
            DirectoryInfo di = new DirectoryInfo("LogFolder");
            if (di.Exists == false) // 해당 폴더 없으면
            {
                di.Create(); // 폴더 생성
            }

            // @가 없으면 "LogFolder\\History.txt"
            // @은 \ 생략하고 \ ' " 사용할 수 있도록
            // 끝에 true는 append = true, 즉 History.txt에 새로운 내용을 밑에다가 계속 추가
            // 이게 없으면 내용 덮어쓰기라서 이전 log가 날아감.
            using(StreamWriter w = new StreamWriter(@"LogFolder\History.txt",true))
            {
                w.Write($"({DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                w.WriteLine(contents);
            }
        }

    }
}
