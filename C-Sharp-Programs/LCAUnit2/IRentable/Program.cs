using System;
using System.Collections.Generic;

namespace IRentable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IRentable";
            Console.ForegroundColor = ConsoleColor.White;

            List<IRentable> inventory = (new List<IRentable>() {
               new Car("Ford Mustang", 38.45),
               new Car("Ford F150", 45.93),
               new House("Two Story - 4 bedrooms - 3 full bathrooms", 645),
               new House("Single Story - 3 bedrooms - 2 full bathrooms", 489),
               new Boat("Pontoon - 10 people", 41.65),
               new Boat("Bass Boat - 3 people", 15.45)
            });

            foreach (var item in inventory)
            {
                item.GetDescription();
                item.GetDailyRate();
            }
            Console.ReadKey();
        }

        class Boat : IRentable
        {
            public string Description { get; set; }
            public double HourlyRate { get; set; }
            public Boat(string item1, double item2)
            {
                this.Description = item1;
                this.HourlyRate = item2;
            }

            public void GetDailyRate()
            {
                //show daily rate with a two hour price break and show price per hour
                Console.WriteLine($"The daily Rate 8 hours from 8am to 5pm: ${(HourlyRate * 6).ToString("F")} or you can rent by the hour at a Rate of: ${HourlyRate} per hour\n");
            }
            public void GetDescription()
            {
                Colors.ChangeColorRed();
                Console.WriteLine("Boat:");
                Colors.ChangeColorRed();
                Console.WriteLine($"Description: {Description}");
            }
        }
        class House : IRentable
        {
            public string Description { get; set; }
            public double WeeklyRate { get; set; }
            public House(string item1, double item2)
            {
                this.Description = item1;
                this.WeeklyRate = item2;
            }

            public void GetDailyRate()
            {
                Console.WriteLine($"Weekly Rate: ${WeeklyRate}\n");
            }
            public void GetDescription()
            {
                Colors.ChangeColorRed();
                Console.WriteLine("House:");
                Colors.ChangeColorRed();
                Console.WriteLine($"Description: {Description}");
            }
        }
        class Car : IRentable
        {
            public string Description { get; set; }
            public double DailyRate { get; set; }
            public Car(string item1, double item2)
            {
                this.Description = item1;
                this.DailyRate = item2;
            }

            public void GetDailyRate()
            {
                Console.WriteLine($"Daily Rate: ${DailyRate}\n");
            }
            public void GetDescription()
            {
                Colors.ChangeColorRed();
                Console.WriteLine("Car:");
                Colors.ChangeColorRed();
                Console.WriteLine($"Description: {Description}");
            }
        }
        interface IRentable
        {
            void GetDailyRate();
            void GetDescription();
        }
        class Colors
        {
            public static void ChangeColorRed()
            {
                Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
            }
        }
    }
}
