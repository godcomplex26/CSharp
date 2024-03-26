using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bulbasaur : Animal, IPlant, IPocketmon
    {
        private int pAge;
        // if문 한 줄에 적는 것은 매우 비권장
        public int age { get { return pAge; } set { if (value < 0) pAge = 0; else pAge = value; }  }
        public string ability { get; set; }

        public virtual void bearFruit()
        {
            Console.WriteLine("아직 그런 거 없어요.");
        }

        public virtual void blooming()
        {
            Console.WriteLine("꽃 봉오리도 없음 ㅇㅇ");
        }

        public void charming()
        {
            Console.WriteLine("이상해씨는 그냥 귀여움");
        }

        public virtual void fight()
        {
            Console.WriteLine("덩쿨로 후드려 팸");
        }

        public virtual void photosynthesis() // 인터페이스에서 온 메서드는 override (X)
        {
            Console.WriteLine("봉오리 끝에서 햇빛을 흡수함");
        }

        public override void sleep() // 추상 클래스에서 온 메서드는 override
        {
            Console.WriteLine("뒤집어져서 자기도 함");
        }
        public override void cry()
        {
            Console.WriteLine("씨씨씨 이상해씨");
        }
        public override void eat()
        {
            Console.WriteLine("덩쿨로 냠냄");
        }
    }
}
