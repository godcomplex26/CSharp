using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal();
            a.name = "뭉치";
            a.age = 10;

            Animal b = new Animal();
            b.name = "루이";
            b.age = 0;

            // Run, Fight는 Program 내에서는 호출 불가능
            a.Sleep();
            a.LivingWorld();
            Console.WriteLine();

            b.Sleep();
            b.LivingWorld();
            Console.WriteLine();

            Cat c = new Cat();
            c.name = "네로";
            c.age = 5;
            c.Meow();
            c.Sleep();
            c.LivingWorld();
            Console.WriteLine();

            Dog d = new Dog();
            d.name = "멍뭉이";
            d.age = 0;
            d.LivingWorld();
            d.Sleep();
            d.Bark();

            List<Animal> zoo = new List<Animal>();
            zoo.Add(a);
            zoo.Add(b);
            zoo.Add(c);
            zoo.Add(d);
            zoo.Add(new Animal());
            zoo.Add(new Dog());
            zoo.Add(new Cat());

            // 다형성이란?
            // 다양한 형태로 변할 가능성
            // A is B, 스마트폰 is 전화기 O
            // 전화기 is 스마트폰 X

            // Cat is Animal O
            // Animal is Cat X
            // 조상 temp = new 자손(); O // 업캐스팅
            Animal aaa = new Cat();
            Animal bbb = new Dog();
            Object o = new Animal(); // 모든 클래스의 조상 Object, object(소문자도 됨)

            // aaa.meow() 하려면 다운캐스팅 필요(업된거만 다운가능)
            ((Cat)(aaa)).Meow();

            if(aaa is Cat) // java에서는 instancOf
            {
                ((Cat)(aaa)).Meow();
                (aaa as Cat).Meow();
            }

            var tempCat = aaa as Cat;
            if (tempCat != null) 
            {
                tempCat.Meow();
            }
            if (tempCat == null)
            {
                Console.WriteLine("고양이가 아님");
            }

            Console.WriteLine();
            Console.WriteLine();
            foreach (var item in zoo)
            {
                item.Sleep(); // 공통 기능
                item.LivingWorld(); // 공통 기능

                if (item is Cat)
                {
                    (item as Cat).Meow();
                }

                if (item is Dog)
                {
                    (item as Dog).Bark();
                }    
            }
        }
    }
}
