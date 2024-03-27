using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookManager
{
    public class DataManager
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        static DataManager()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                string booksOutput = File.ReadAllText(@"./Books.xml");
                XElement booksXElement = XElement.Parse(booksOutput);
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
                string usersOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXElement = XElement.Parse(usersOutput);
                Users = (from item in usersXElement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>();
            }
            catch (FileLoadException ex)
            {
                Save(); // 처음 프로젝트 실행 시 Books.xml / Users.xml 없기 때문에 만들어 줌
            }

            catch (FileNotFoundException ex)
            {
                Save(); // ppt에 이거 빠져있는데, 이거 처리 해주니까 된다.
            }
        }

        public static void Save()
        {
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach (var item in Books)
            {
                booksOutput += "<book>\n";
                booksOutput += " <isbn>" + item.Isbn + "</isbn>\n";
                booksOutput += " <name>" + item.Name + "</name>\n";
                booksOutput += " <publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += " <page>" + item.Page + "</page>\n";
                booksOutput += " <borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += " <isBorrowed>" + (item.isBorrowed ? 1 : 0) + "</isBorrowed>\n";
                booksOutput += " <userId>" + item.UserId + "</userId>\n";
                booksOutput += " <userName>" + item.UserName + "</userName>\n";
                booksOutput += "</book>\n";
            }
            booksOutput += "</books>";

            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach (var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += " <id>" + item.Id + "</id>\n";
                usersOutput += " <name>" + item.Name + "</name>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>";

            // 저장
            File.WriteAllText(@"./Books.xml", booksOutput);
            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
