using System;
using System.Collections.Generic;

namespace SuperHeroesVillains
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Person P1 = new Person("Richard", "Dick");
            Console.WriteLine($"{P1.Name}{P1.NickName}");
            Console.WriteLine(P1.ToString());*/

            var personList = new List<Person>() {
            new Person("William", "Bill"),
            new SuperHero("Wade Turner", "Mr. Incredible", "Super Strength"),
            new Villain("Joker", "Batman"),
            };
            
            foreach (var item in personList)
            {
                item.PrintGreeting();
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string NickName { get; set; }

        public Person(string item1, string item2)
        {
            this.Name = item1;
            this.NickName = item2;
        }

        public override string ToString()
        {
            return $"\nName: {Name}";
        }
        public virtual void PrintGreeting()
        {
            Console.WriteLine($"Hi, my name is {Name}, you can call me {NickName}.\n");
        }
    }

    class SuperHero : Person
    {
        public string HeroName { get; set; }
        public string SuperPower { get; set; }

        public SuperHero(string item1, string item2, string item3) : base(item1, null)
        {
            this.HeroName = item2;
            this.SuperPower = item3;
        }

        public override void PrintGreeting()
        {
            Console.WriteLine($"I am {Name}. When I am {HeroName}, my super power is {SuperPower}!\n");
        }
    }

    class Villain : Person
    {
        public string Nemesis { get; set; }

        public Villain(string item1, string item2) : base(item1, null)
        {
            this.Nemesis = item2;
        }

        public override void PrintGreeting()
        {
            Console.WriteLine($"I am The {Name}! Have you seen {Nemesis}?\n");
        }
    }
}
