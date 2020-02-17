using System;


namespace CheckerV4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Checkers";
            Game game = new Game();
            game.Start();
        }
    }
}
