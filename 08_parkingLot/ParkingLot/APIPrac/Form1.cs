using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIPrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // JSON 형식이라면 별도의 라이브러리(nuget 패키지 활용) 필요
            // XML 형식이라면 별도의 라이브러리가 필요하진 않음

            // XML도 기상청에서 이미 해봤고, 승인받고 가져다 쓰는 방식은 유사하다.
            // XML은 태그 형태에 따라서 코드가 좀 달라질 수 있다.
            string url = "https://api.odcloud.kr/api/3082925/v1/uddi:b4759786-c28c-41dd-b600-a9abdbec3ae1?page=1&perPage=10&returnType=JSON&serviceKey=pR%2BsfLke7qwiEQPi9HJ3%2FYZZeU9xvpxhMQqwLvAQf67%2BJapLqVLTODWiFbw3pnVqd4XER2bByN6%2Bm%2FtevVxBDQ%3D%3D";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString(url);
            var jArray = JObject.Parse(json);
            var jData = jArray["data"];

            dataGridView1.Rows.Clear();
            foreach ( var item in jData )
            {
                dataGridView1.Rows.Add(item["상호명"].ToString(), item["소재지도로명주소"]);
            }
        }
    }
}
