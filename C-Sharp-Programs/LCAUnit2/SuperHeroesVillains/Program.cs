using System;
using System.Collections.Generic;

namespace SuperHeroesVillains
{
    class Program
    {
        static void Main(string[] args)
        {
            //List
            var personList = new List<Person>() {
            new Person("William", "Bill"),
            new SuperHero("Wade Turner", "Mr. Incredible", "Super Strength"),
            new Villain("Joker", "Batman"),
            };
            
            //loop through methods
            foreach (var item in personList)
            {
                item.PrintGreeting();
            }
        }
    }
    class Person
    {
        //prop
        public string Name { get; set; }
        public string NickName { get; set; }

        //Ctor
        public Person(string item1, string item2)
        {
            this.Name = item1;
            this.NickName = item2;
        }

        //Method
        public override string ToString()
        {
            return $"\nName: {Name}";
        }
        //Method
        public virtual void PrintGreeting()
        {
            Console.WriteLine($"Hi, my name is {Name}, you can call me {NickName}.\n");
        }
    }

    class SuperHero : Person
    {   //prop
        public string HeroName { get; set; }
        public string SuperPower { get; set; }

        //ctor
        public SuperHero(string item1, string item2, string item3) : base(item1, null)
        {
            this.HeroName = item2;
            this.SuperPower = item3;
        }

        //method
        public override void PrintGreeting()
        {
            Console.WriteLine($"I am {Name}. When I am {HeroName}, my super power is {SuperPower}!\n");
        }
    }

    class Villain : Person
    {
        //prop
        public string Nemesis { get; set; }

        //ctor
        public Villain(string item1, string item2) : base(item1, null)
        {
            this.Nemesis = item2;
        }

        //method
        public override void PrintGreeting()
        {
            Console.WriteLine($"I am The {Name}! Have you seen {Nemesis}?\n");
        }
    }
}
