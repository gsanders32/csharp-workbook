using System;
using static ToDoApp.Colors;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "To Do App"; //set title
            Console.BackgroundColor = ConsoleColor.White; //change background to white
            Console.Clear(); //force refresh so screen is white
            Change(Color.Black); //set text to black
            App app = new App(); //create new instance of app class
            app.Start(); //call start method
        }
    }
}
