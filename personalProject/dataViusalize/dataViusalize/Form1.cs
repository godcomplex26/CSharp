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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace dataViusalize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series[0].Name = "화재발생건수";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://api.odcloud.kr/api/15060386/v1/uddi:9951ec3f-d1c9-49e8-9ed4-f026c39a7925?page=1&perPage=50&returnType=JSON&serviceKey=pR%2BsfLke7qwiEQPi9HJ3%2FYZZeU9xvpxhMQqwLvAQf67%2BJapLqVLTODWiFbw3pnVqd4XER2bByN6%2Bm%2FtevVxBDQ%3D%3D";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString(url);
            var jArray = JObject.Parse(json);
            var jData = jArray["data"];

            List<string> localList = new List<string>();
            localList.Clear();

            dataGridView1.Rows.Clear();
            foreach (var item in jData)
            {
                dataGridView1.Rows.Add(item["일시"].ToString(), item["시_군_구"], item["시도"], item["부상"], item["사망"], item["재산피해소계"], item["장소대분류"], item["장소중분류"], item["장소소분류"]);
                if (!localList.Contains(item["시도"].ToString()))
                {
                    localList.Add(item["시도"].ToString());
                }                
            }

            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 0.5; // x축 간격
            chart1.Series[0]["PixelPointWidth"] = "20";
            for (int i = 0; i < localList.Count; i++)
            {
                chart1.Series["화재발생건수"].Points.AddXY(localList[i], localList[i].Count());
            }
        }
    }
}
