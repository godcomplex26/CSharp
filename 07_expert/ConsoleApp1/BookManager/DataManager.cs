using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookManager
{
    public class DataManager
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        // 정적 생성자
        // 딱 한 번만 호출되고, 다른 코드에서 DataManager가 처음 나타날 때 자동 호출 됨
        static DataManager()
        {
            Load();
        }

        // 도서, 유저 정보를 xml 파일에서 읽어오는 함수
        public static void Load()
        {
            try // exe와 같은 경로에 파일이 있을 경우(BookManager\bin\Debug\)
            {
                string booksOutput = File.ReadAllText(@"./Books.xml");
                XElement booksXElement = XElement.Parse(booksOutput);

                Books.Clear();
                foreach(var item in booksXElement.Descendants("book"))
                {
                    Book book = new Book();
                    book.Isbn = item.Element("isbn").Value;
                    book.Name = item.Element("name").Value;
                    book.Publisher = item.Element("publisher").Value;
                    book.Page = int.Parse(item.Element("page").Value);
                    book.BorrowedAt = DateTime.Parse(item.Element("borrowedAt").Value);
                    book.isBorrowed = item.Element("isBorrowed").Value != "0" ? true : false;
                    book.UserId = int.Parse(item.Element("userId").Value);
                    book.UserName = item.Element("userName").Value;
                    Books.Add(book);
                }

                string usersOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXElement = XElement.Parse(usersOutput);

                Users.Clear();
                foreach(var item in usersXElement.Descendants("user"))
                {
                    User user = new User();
                    user.Id = int.Parse(item.Element("id").Value);
                    user.Name = item.Element("name").Value;
                    Users.Add(user);
                }
                
                // linq를 사용하면, 코드 한 줄이 ,로 구분되어 길어지므로 디버깅이 어렵다.
/*
                Books = (from item in booksXElement.Descendants("book")
                         select new Book()
                         {
                             Isbn = item.Element("isbn").Value,
                             Name = item.Element("name").Value,
                             Publisher = item.Element("publisher").Value,
                             Page = int.Parse(item.Element("page").Value),
                             BorrowedAt = DateTime.Parse(item.Element("borrowedAt").Value),
                             isBorrowed = item.Element("isBorrowed").Value != "0" ? true : false,
                             UserId = int.Parse(item.Element("userId").Value),
                             UserName = item.Element("userName").Value
                         }).ToList<Book>();
                
                Users = (from item in usersXElement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>();
*/
            }
            catch (Exception ex)
            {
                Save(); // 처음 프로젝트 실행 시 Books.xml / Users.xml 없기 때문에 만들어 줌
            }
        }

        // 도서, 유저 정보를 xml 파일에 저장하는 함수
        public static void Save()
        {
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach (var item in Books)
            {
                // "\n" ==  Environment.NewLine
                booksOutput += "    <book>\n";
                // booksOutput += " <book>" + Environment.NewLine;
                booksOutput += "        <isbn>" + item.Isbn + "</isbn>\n";
                booksOutput += "        <name>" + item.Name + "</name>\n";
                booksOutput += "        <publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += "        <page>" + item.Page + "</page>\n";
                booksOutput += "        <borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += "        <isBorrowed>" + (item.isBorrowed ? 1 : 0) + "</isBorrowed>\n";
                booksOutput += "        <userId>" + item.UserId + "</userId>\n";
                booksOutput += "        <userName>" + item.UserName + "</userName>\n";
                booksOutput += "    </book>\n";
            }
            booksOutput += "</books>";

            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "    <user>\n";
                usersOutput += "        <id>" + item.Id + "</id>\n";
                usersOutput += "        <name>" + item.Name + "</name>\n";
                usersOutput += "    </user>\n";
            }
            usersOutput += "</users>";

            // 저장
            File.WriteAllText(@"./Books.xml", booksOutput);
            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
