using System; // using = import
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 프로그램이 커지고, 복잡해져서 작명의 한계를 해결하기 위한 개념으로 등장
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 주석, 주석은 타자에 자신 없으면 따라 적지 마세요.
            // 타자 자체에 자신이 없으면 그냥 코드를 보셔도 됩니다.
            // 동영상 녹화, github 공유, 공유 폴더에 공유함.

            // cw 적고 tab 1회 -> WriteLine() / 2회 -> Write()
            // Console.WriteLine(); == System.out.println();
            // Console.Write(); == System.out.print();
            Console.WriteLine("안녕"); // 실행 ctrl + f5
            Console.Write("Hello"); // write는 개행이 없다.
            Console.Write("World!"); // ctrl + d 누르면 한 줄 복붙
            Console.Write("World!");
            Console.WriteLine(); // 그냥 한 줄 개행
            Console.WriteLine(); // 그냥 한 줄 개행
            Console.WriteLine(); // 그냥 한 줄 개행
            Console.WriteLine(); // 그냥 한 줄 개행

            // 자바에서 sysout 적으면 System.out.println() 생기 듯
            // c#에서 cw적고 tab키 두 번 누르면 Console.WriteLine() 생김
            // 이러한 cw 등을 코드 조각이라고 부르고 사용자가
            // 직접 새로운 코드 조각도 만들 수 있다.

            Console.WriteLine("WriteWriteLine");
            Console.WriteLine("WriteLine");
            Console.WriteLine("WriteLine");
            Console.WriteLine("WriteWrite");
        }
    }
}