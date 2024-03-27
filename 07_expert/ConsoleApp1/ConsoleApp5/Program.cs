using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.weather.go.kr/w/rss/dfs/hr1-forecast.do?zone=2714055500
            string url = "https://www.weather.go.kr/w/rss/dfs/hr1-forecast.do?zone=2714055500";
            XElement x = XElement.Load(url); // url 사이트에 있는 xml 문서를 불러 옴
            var xq = from item in x.Descendants("data") select item; // <data> 태그에 있는 내용을 가져온다

            // xml 문서를 그대로 긁어와서 뿌린 것
            foreach (var item in xq)
            {
                Console.WriteLine(item);
            }

            // xml 문서 중 일부 태그만 가져와서 뿌린 것
            foreach (var item in xq)
            {
                Console.WriteLine("시간 : " + item.Element("hour").Value); // <hour> 태그에 있는 내용을 가져온다
                Console.WriteLine("온도 : " + item.Element("temp").Value);
                Console.WriteLine("날씨 : " + item.Element("wfKor").Value);
            }

            // xml 문서의 일부 태그를 익명 객체 데이터 형태로 가공해서 사용
            var xmlQuery = from item in x.Descendants("data")
                           select new
                           {
                               hour = item.Element("hour").Value,
                               temp = item.Element("temp").Value,
                               wfKor = item.Element("wfKor").Value
                           };

            foreach (var item in xmlQuery)
            {
                Console.WriteLine("시간 : " + item.hour);
                Console.WriteLine("온도 : " + item.temp);
                Console.WriteLine("날씨 : " + item.wfKor);
            }

            // 클래스 이용하여 가공해서 사용
            var xmlWq = from item in x.Descendants("data")
                           select new Weather()
                           {
                               hour = item.Element("hour").Value,
                               temp = item.Element("temp").Value,
                               wfKor = item.Element("wfKor").Value
                           };

            foreach (var item in xmlWq)
            {
                Console.WriteLine("시간 : " + item.hour);
                Console.WriteLine("온도 : " + item.temp);
                Console.WriteLine("날씨 : " + item.wfKor);
            }
           
        }
    }
}
