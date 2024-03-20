using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp002_8
{
    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }

        // 접근 제한자 없으면 private이 기본
        // private은 해당 클래스 안에서만 접근 가능
        // 다른 클래스에서 접근 불가
        string description { get; set; }
        private int vipPrice { get; set; }

        // 생성자 적지 않아도 디폴트(매개변수 없는 것) 생성자는 기본 생성됨
        // public Product() {}

        // 생성자 : new 키워드와 함께 쓰이고, 메모리를 할당하는 시점에 뭘 할지 정해 주는 것

        // 명시적으로 적으면 디폴트는 없어짐. 후에 디폴트 쓰고 싶으면 명시적으로 디폴트 쓸 것
        // 이젠 명시 전까지 디폴트 불가능

        // 웬만하면 생성자는 public
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        // 생성자 역시 오버로딩 가능
        public Product(string name)
        {
            this.name=name;
            Console.WriteLine("아직 가격은 몰라요");
        }


    }
}
