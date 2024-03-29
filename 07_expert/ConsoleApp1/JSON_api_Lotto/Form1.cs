using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON_api_Lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=";
            int count = 1000; // 로또 1000회차 부터 현재 회차까지 출력을 할 것

            while(true)
            {
                using(WebClient wc = new WebClient()) // using 끝나면 wc는 메모리 해제
                {
                    var json = wc.DownloadString(url+count);
                    count++;
                    var jArray = JObject.Parse(json); // using Newtonsoft.Json.Linq = josn 라이브러리 깔아서 그렇다.
                    if (jArray["returnValue"].ToString() != "success") // == fail;
                    {
                        break;
                    }
                    dataGridView1.Rows.Add(jArray["drwNo"].ToString(), jArray["drwNoDate"].ToString());
                }
            }
        }
    }
}
