using System;

namespace PoCos
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverLicense license01 = new DriverLicense();
            license01.FirstName = "Gray";
            license01.LastName = "Sanders";
            license01.Gender = "Male";
            license01.LicenseNumber = 15789458;

            Book book01 = new Book();
            book01.Title = "The History of C#";
            book01.Author = new string[2];
            book01.Author[0] = "Gray Sanders";
            book01.Author[1] = "Clara Sanders";
            book01.Pages = 178;
            book01.SKU = "FG345SGV2353";
            book01.Publisher = "Sanders Inc";
            book01.Price = 19.99;

            Airplane airplane01 = new Airplane();
            airplane01.Manufacturer = "Boeing";
            airplane01.Model = "DC7";
            airplane01.Variant = "X4";
            airplane01.Capacity = 250;
            airplane01.Engines = 2;

            Console.WriteLine(license01.Display());
            Console.WriteLine(book01.Display());
            Console.WriteLine(airplane01.Display());
            Console.ReadKey();

            
        }
        class DriverLicense
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int LicenseNumber { get; set; }
            public string Display()
            {
                return "Driver License" +
                    "\nFull Name: " + FirstName + " " + LastName + 
                    "\nlicense number: " + LicenseNumber + 
                    "\nGender: " + Gender + "\n";
            }
        }
        class Book
        {
            public string Title { get; set; }
            public string[] Author { get; set; }
            public int Pages { get; set; }
            public string SKU { get; set; }
            public string Publisher { get; set; }
            public double Price { get; set; }
            public string Display()
            {
                return "Book" +
                    "\nTitle: " + Title + 
                    "\nAuthor: " + string.Join(", ",Author) +
                    "\nNumber of pages: " + Pages +
                    "\nSKU: " + SKU +
                    "\nPublisher: " + Publisher +
                    "\nPrice: $" + Price + "\n";
            }
        }
        class Airplane
        {
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Variant { get; set; }
            public int Capacity { get; set; }
            public int Engines { get; set; }
            public string Display()
            {
                return "Airplane" +
                    "\nManufacturer: " + Manufacturer +
                    "\nModel: " + Model +
                    "\nVariant: " + Variant +
                    "\nCapacity: " + Capacity +
                    "\nEngines: " + Engines;
            }
        }
    }
}
