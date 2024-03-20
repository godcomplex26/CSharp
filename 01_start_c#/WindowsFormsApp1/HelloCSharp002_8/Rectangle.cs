using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp002_8
{
    internal class Rectangle // 사각형
    {
        public int width {  get; set; } // 각 사각형마다
        public int height { get; set; } // 너비, 높이 다름
        public static string color { get; set; } // 모두 색깔은 같다고 가정

        // 인스턴스 메서드(인스턴스에 따라 결과 변함)
        public int getArea() { return width * height; } // 자신의 넓이 계산

        // 클래스 메서드(매개변수에 따라 결과 변함)
        public static int calcRecArea(int w, int h) { return w * h; } // 해당 매개 변수 반영하여 넓이 계산
        
        // 클래스 메서드를 인스턴스를 활용하여 사용
        public static int calcRecArea(Rectangle rect) { return rect.width * rect.height;} 
    }
}
