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

            Console.WriteLine($"{license01.FirstName} {license01.LastName} license number: {license01.LicenseNumber} is a {license01.Gender}");

            Book book01 = new Book();
            book01.Title = "The History of C#";
            book01.Author = new string[2];
            book01.Author[0] = "Gray Sanders";
            book01.Author[1] = "Clara Sanders";
            book01.Pages = 178;
            book01.SKU = "FG345SGV2353";
            book01.Publisher = "Sanders Inc";
            book01.Price = 19.99;

            Console.WriteLine($"Title: {book01.Title}, Author(s): {book01.Author[0]}, {book01.Author[1]}, Pages: {book01.Pages}, SKU: {book01.SKU}, Publisher: {book01.Publisher}, Price: ${book01.Price}");

            Airplane airplane01 = new Airplane();
            airplane01.Manufacturer = "Boeing";
            airplane01.Model = "DC7";
            airplane01.Variant = "X4";
            airplane01.Capacity = 250;
            airplane01.Engines = 2;

            Console.WriteLine($"Manufacturer: {airplane01.Manufacturer}, Model: {airplane01.Model}, Variant: {airplane01.Variant}, Capacity: {airplane01.Capacity}, Capacity: {airplane01.Engines}");
            Console.ReadKey();

            
        }
        class DriverLicense
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int LicenseNumber { get; set; }
        }
        class Book
        {
            public string Title { get; set; }
            public string[] Author { get; set; }
            public int Pages { get; set; }
            public string SKU { get; set; }
            public string Publisher { get; set; }
            public double Price { get; set; }

        }
        class Airplane
        {
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Variant { get; set; }
            public int Capacity { get; set; }
            public int Engines { get; set; }
        }
    }
}
