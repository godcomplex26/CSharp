using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPrac
{
    // 싱글톤 패턴 : 단 한 번만 인스턴스를 선언한 뒤, 그 인스턴스를 여러 클래스에서 공유
    // 메모리 절약 - static이 붙은 클래스 메서드나 클래스 변수에 비해 메모리가 절약
    // static이 붙은 건 상속이 안 됨(오버라이드 등이 안 됨) -> 싱글톤을 쓰면 오버라이드 가능
    // -> static 처럼 쓰고 싶다.
    public class MyMath
    {
        // MyMath.Power(5) = 25
        // a.Power(5) = 25. a를 여러 클래스에서 계속 갖다 쓰는 것

        // 스태틱 인스턴스를 하나 만들고
        private static MyMath instance = null;

        private MyMath()
                {

                }

        // 그 인스턴스를 계속 가져와서 재활용 시킴, 단 하나의 인스턴스
        public static MyMath getInstance()
        {
            if (instance == null)
            {
                instance = new MyMath();
            }
            return instance;
        }

        public int power(int x)
        {
            return x * x;
        }

        public int plus(int x, int y)
        {
            return x + y;
        }

        public int minus(int x, int y)
        {
            return x - y;
        }
     }   
}
