using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp002_3
{
    public class Product // internal을 public으로 바꾸기
    {
        // { get; set; } = java의 Getter/Setter와 같은 것
        // Getter/Setter를 축약한 것
        // name, price 는 인스턴스 변수, 인스턴스 별로 값이 다름
        // countOfProduct 는 클래스 변수, 클래스 공통 값

        public string name { get; set; }
        public int price {  get; set; }

        public static int countOfProduct = 0;

        // public Product() : 아무것도 없는 기본 생성자는 자동으로 생김 - 디폴트 생성자
    }
}
