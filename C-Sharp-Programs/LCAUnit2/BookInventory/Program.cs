using System;

namespace BookInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Book Inventory";
            CRUD crud = new CRUD();
            crud.Start();
        }
    }
}
