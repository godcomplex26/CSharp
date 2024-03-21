using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            if (aaa is Cat) // java에서는 instancOf
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

            Animal.zooName = "경북동물원";
            Console.WriteLine(Dog.zooName);
            Console.WriteLine(Cat.zooName);

            Console.WriteLine();
            Console.WriteLine();

            Animal ani1 = new Animal();
            Cat cat1 = new Cat();
            Dog dog1 = new Dog();
            Animal cat2 = new Cat();
            Animal dog2 = new Dog();

            // Eat=묵시적 하이딩, Charm=오버라이딩, Cry=명시적 하이딩
            ani1.Eat(); // Animal ani1 = new Animal();
            ani1.Charm();
            ani1.Cry();
            Console.WriteLine();

            cat1.Eat(); // Cat cat1 = new Cat();
            cat1.Charm();
            cat1.Cry();
            Console.WriteLine();

            dog1.Eat(); // Dog dog1 = new Dog();
            dog1.Charm();
            dog1.Cry();
            Console.WriteLine();

            cat2.Eat(); // Animal cat2 = new Cat(); // 하이딩된 건 부모껄 로, 오버라이딩 된거만 자식껄로
            cat2.Charm();
            cat2.Cry();
            Console.WriteLine();

            dog2.Eat(); // Animal dog2 = new Dog(); // 하이딩된 건 부모껄로, 오버라이딩 된거만 자식껄로
            dog2.Charm();
            dog2.Cry();
            Console.WriteLine();

            List<Animal> animals = new List<Animal>();
            animals.Add(ani1);
            animals.Add(cat1);
            animals.Add(dog1);
            animals.Add(cat2);
            animals.Add(dog2);

            foreach(Animal animal in animals)
            {
                animal.Eat();
                animal.Charm(); // 오버라이딩은 해당 클래스의 메서드가 무조건 나옴
                animal.Cry();
            }

        }
    }
}
