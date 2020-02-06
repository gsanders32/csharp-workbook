using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Car Lot";
            Console.ForegroundColor = ConsoleColor.White;

            //new lot
            CarLot sandersFord = new CarLot("Sanders Ford", new List<Vehicle>(){
                new Car("KFF-5767", "Ford", "Mustang", 28500, "Coupe", 2),
                new Car("LJY-9346", "Ford", "Explorer", 48750, "SUV", 4),
                new Truck("TYR-2458", "Ford", "F-150", 42900, 5.5),
                new Truck("DFR-5734", "Ford", "Raptor", 79458, 5),
            });
            //i can also add vehicles this way
            sandersFord.VehicleList.Add(new Car("XRT-3456", "Ford", "Fusion", 23170, "Sedan", 4));

            //new lot
            CarLot sandersHonda = new CarLot("Sanders Honda", new List<Vehicle>(){
                new Car("JRT-8454", "Honda", "Insight", 22930, "Sedan", 4),
                new Car("YDJ-2845", "Honda", "Civic", 21750, "Hatchback", 4),
                new Car("BRT-0457", "Honda", "Pilot", 31650, "SUV", 4),
                new Truck("AQW-8274", "Honda", "Ridgeline", 33900, 5.3),
            });

            //print car lot
            sandersFord.PrintCarLot();
            sandersHonda.PrintCarLot();

            Console.ReadKey();
        }
    }
    class CarLot
    {
        //Properties
        public string Name { get; set; }
        public List<Vehicle> VehicleList { get; set; }

        //constructor
        public CarLot(string item01, List<Vehicle> item02)
        {
            this.Name = item01;
            this.VehicleList = item02;
        }
        //method to print
        public void PrintCarLot()
        {
            Colors.LotColor();
            Console.WriteLine($"{Name} - Vehicle Inventory:\n");
            Colors.LotColor();
            foreach (var item in VehicleList)
            {           
                Console.WriteLine(item.Info());
            }
        }
    }

    abstract class Vehicle
    {
        //Properties
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }

        //constructor
        public Vehicle(string item01, string item02, string item03, int item04)
        {
            this.LicenseNumber = item01;
            this.Make = item02;
            this.Model = item03;
            this.Price = item04;
        }

        //Method returns vehicle info
        public virtual string Info()
        {
            return "";
        }
    }

    class Car : Vehicle
    {
        //Properties
        public string Type { get; set; }
        public int NumberOfDoors { get; set; }

        //constructor
        public Car(string item01, string item02, string item03, int item04, string item05, int item06) : base(item01, item02, item03, item04)
        {
            Type = item05;
            NumberOfDoors = item06;
        }

        //Method returns vehicle and car info
        public override string Info()
        {
            return $"Vehicle Type = Car" +
                $"\nLicense Number: {LicenseNumber}" +
                $"\nMake: {Make}" +
                $"\nModel: {Model}" +
                $"\nPrice: ${string.Format("{0:n0}", Price)}" +
                $"\nType: {Type}" +
                $"\nNumber Of Doors: {NumberOfDoors}\n";
        }
    }

    class Truck : Vehicle
    {
        //Properties
        public double BedSize { get; set; }

        //constructor
        public Truck(string item01, string item02, string item03, int item04, double item05) : base(item01, item02, item03, item04)
        {
            BedSize = item05;
        }

        //Method returns vehicle and truck info
        public override string Info()
        {
            return $"Vehicle Type = Truck" +
                $"\nLicense Number: {LicenseNumber}" +
                $"\nMake: {Make}" +
                $"\nModel: {Model}" +
                $"\nPrice: ${string.Format("{0:n0}", Price)}" +
                $"\nBed Size: {BedSize} ft\n";
        }
    }

    class Colors
    {
        public static void LotColor()
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Red : ConsoleColor.White;
        }
        public static void PriceColor()
        {
            Console.ForegroundColor = Console.ForegroundColor == ConsoleColor.White ? ConsoleColor.Green : ConsoleColor.White;
        }
    }
}
