using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataManager.Load();
            if (DataManager.Cars.Count > 0) // Count가 0 이하일 때는 코드 실행되면 안 됨. 오류 난다.
            {
                dataGridView1.DataSource = DataManager.Cars;
                textBox1.Text = DataManager.Cars[0].parkingspot;
                textBox2.Text = DataManager.Cars[0].carnumber;
                textBox3.Text = DataManager.Cars[0].drivername;
                textBox4.Text = DataManager.Cars[0].phonenumber;
                textBox5.Text = textBox1.Text;
            }
        }

        private void WriteLog(string contents)
        {
            DataManager.PrintLog(contents);
            string log = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}]";
            log += contents;
            listBox1.Items.Insert(0, log); //최신 내용이 맨 위에 올라감
            //listBox1.Items.Add(contents); //최신 내용이 맨 아래로 내려감
        }

        // 주차
        private void button1_Click(object sender, EventArgs e)
        {
            //writeLog("버튼 1 클릭(주차)");
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("주차 공간 번호 입력하세요(주차)");
            else if (textBox2.Text.Trim() == "")
                MessageBox.Show("차량 번호 입력해주세요.");
            else
            {
                try
                {
                    ParkingCar car = DataManager.Cars.Single
                        (x => x.parkingspot == textBox1.Text.Trim());
                    if (car.carnumber.Trim() != "")
                        MessageBox.Show("해당 공간에 이미 차가 있습니다!");
                    else //주차 시작
                    {
                        car.parkingspot = textBox1.Text.Trim();
                        car.carnumber = textBox2.Text;
                        car.drivername = textBox3.Text;
                        car.phonenumber = textBox4.Text;
                        car.parkingtime = DateTime.Now;

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Cars; //sw(=화면)에 반영

                        DataManager.Save(car);//주차한 걸 db에 반영
                        string contents = $"주차공간 {car.parkingspot}에 {car.carnumber}차를 주차함";
                        WriteLog(contents);
                        MessageBox.Show(contents);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("해당 공간 없어서 주차 불가능!");
                    WriteLog($"주차 공간{textBox1.Text} 존재하지 않음!");
                }
            }
        }

        // 출차
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "")
            {
                MessageBox.Show("주차 공간 번호를 입력하세요(출차");
            }
            else
            {
                try
                {
                    ParkingCar car = DataManager.Cars.Single
                        (x => x.parkingspot == textBox1.Text);
                    if (car.carnumber.Trim() == "")
                    {
                        MessageBox.Show("차가 없으므로 출차 불가능");
                    }
                    else
                    {
                        string oldCar = car.carnumber;//기존에 주차된 차
                        car.parkingspot = textBox1.Text;
                        car.carnumber = "";
                        car.drivername = "";
                        car.phonenumber = "";
                        car.parkingtime = new DateTime();
                        //car.parkingTime = DateTime.Parse("1753-01-01 오전 12:00:00");

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DataManager.Cars;

                        DataManager.Save(car);
                        string contents = $"주차공간 {car.parkingspot} 에서 {oldCar} 출차";
                        WriteLog(contents);
                        MessageBox.Show(contents);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"주차 공간{textBox1.Text} 없음(출차)");
                    WriteLog($"주차 공간{textBox1.Text} 없음(출차)");
                }
            }
        }

        // 조회
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ParkingCar car = DataManager.Cars.Single(x => x.parkingspot == textBox5.Text);
                if (car.carnumber == "")
                {
                    MessageBox.Show($"{car.parkingspot} 공간에는 차가 없음");
                    WriteLog($"{car.parkingspot} 공간에는 차가 없음");
                }
                else
                {
                    MessageBox.Show($"{car.parkingspot} 공간에는 {car.carnumber} 있음");
                    WriteLog($"{car.parkingspot} 공간에는 {car.carnumber} 있음");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("해당 주차 공간 없음(조회 기능)");
            }
        }

        private void managingSpot(string parkingSpot, string cmd)
        {
            parkingSpot = parkingSpot.Trim(); // 공백 제거
            string contents = "";
            bool check = DataManager.Save(cmd, parkingSpot, out contents); // 추가 or 삭제 후 성공 시 true / 실패 시 false
            if (check) // 추가 or 삭제 성공
            {
                button6.PerformClick(); // 전체 조회
            }
            MessageBox.Show(contents);
            WriteLog(contents);
        }

        // 주차 공간 추가
        private void button4_Click(object sender, EventArgs e)
        {
            managingSpot(textBox5.Text, "insert");
        }

        // 주차 공간 삭제
        private void button5_Click(object sender, EventArgs e)
        {
            managingSpot(textBox5.Text, "delete");
        }

        // 전체 조회
        private void button6_Click(object sender, EventArgs e)
        {
            DataManager.Load();
            dataGridView1.DataSource = null;
            if (DataManager.Cars.Count > 0)
            {
                dataGridView1.DataSource = DataManager.Cars;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ParkingCar car = dataGridView1.CurrentRow.DataBoundItem as ParkingCar;
            textBox1.Text = car.parkingspot;
            textBox2.Text = car.carnumber;
            textBox3.Text = car.drivername;
            textBox4.Text = car.phonenumber;
            textBox5.Text = textBox1.Text;
        }
    }
}
