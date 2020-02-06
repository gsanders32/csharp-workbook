using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace scratchpad
{
    public class Program
    {
        public static void Main()
        {
            Cat molly = new Cat();
            Dog patrick = new Dog();
            Animal garfield = new Cat();
            Animal rocky = new Dog();

            // cannot instantiate an Animal instance
            // since the Animal class is an abstract class
            // Animal other = new Animal()

            List<Animal> myList = new List<Animal>();
            myList.Add(molly);
            myList.Add(patrick);
            myList.Add(garfield);
            myList.Add(rocky);

            foreach (Animal animal in myList)
            {
                Console.WriteLine(animal.sing());
                Console.WriteLine(animal.talk());
            }
        }
    }

    public abstract class Animal
    {
        public virtual String talk() { return "Hola"; }
        public virtual string sing() { return "walala"; }
    }

    public class Cat : Animal
    {
        public override String talk() { return "Meow!!!"; }
    }

    public class Dog : Animal
    {
        public override String talk() { return "Woof!!!"; }
        public override string sing() { return "bark bark bark"; }
    }

}
