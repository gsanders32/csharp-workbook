using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Let's play MasterMind");
            Console.WriteLine("\nHow to play:");
            Console.WriteLine("\nThe Player will try and guess the two colors the computer picked in order");
            Console.WriteLine("\nThe computer will select 2 colors at random from (Red, Yellow and Blue). The colors can repeat.");
            Console.WriteLine("\nYou will get hints to help you pick the right colors and order");
            GameHints();
            ComputerPicks();
            GamePlay();
        }

        static string UserColor1;
        static string UserColor2;
        static string ComputerColor1;
        static string ComputerColor2;
        static string[] colors = new string[3] { "Red", "Yellow", "Blue" };

        static void GameHints()
        {
            Console.WriteLine("0 - 0 You did not guess the correct colors at all");
            Console.WriteLine("1 - 0 You guessed one of the colors correctly but not at the correct position");
            Console.WriteLine("0 - 1 You guessed one of the colors correctly at the correct position");
            Console.WriteLine("2 - 0 You guessed both colors correctly but at the wrong positions");
        }
        static void ComputerPicks()
        {
            //create pc move
            Random rand = new Random();
            
            int color1 = rand.Next(colors.Length); //pick random number
            int color2 = rand.Next(colors.Length); //pick random number

            ComputerColor1 = colors[color1]; //get the color
            ComputerColor2 = colors[color2]; //get the color
        }
        static bool UserPicks(string userColor)
        {
            if (userColor == "r" || userColor == "y" || userColor == "b")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void GamePlay()
        {
            string color;
            do
            {
                Console.WriteLine("\nSelect your First color R = Red, Y = Yellow, and B = Blue");
                color = Console.ReadLine().ToLower();
                UserPicks(color);
                switch (color)
                {
                    case "r":
                        UserColor1 = "Red";
                        break;
                    case "y":
                        UserColor1 = "Yellow";
                        break;
                    case "b":
                        UserColor1 = "Blue";
                        break;
                }
            } while (!UserPicks(color));

            do
            {
                Console.WriteLine("\nSelect your Second color R = Red, Y= Yellow, and B=Blue");
                color = Console.ReadLine().ToLower();
                UserPicks(color);
                switch (color)
                {
                    case "r":
                        UserColor2 = "Red";
                        break;
                    case "y":
                        UserColor2 = "Yellow";
                        break;
                    case "b":
                        UserColor2 = "Blue";
                        break;
                }
            } while (!UserPicks(color));

            //Testing
            /*string ComputerColor1 = "Blue";
            string ComputerColor2 = "Blue";*/
            if (UserColor1 == ComputerColor1 && UserColor2 == ComputerColor2)
            {
                Console.WriteLine("\nGreat job you guested both colors!!");
                Console.WriteLine("\nWould you like to play again? Y/N");
                string again = Console.ReadLine().ToLower();
                if(again == "y" || again == "yes")
                {
                    Console.Clear();
                    ComputerPicks();
                    GameHints();
                    GamePlay();
                }
            }
            else if (UserColor1 == ComputerColor2 && UserColor2 == ComputerColor1 )
            {
                Console.WriteLine("2 - 0 You guessed both colors correctly but at the wrong positions");
                GamePlay();
            }
            else if (UserColor1 == ComputerColor1 || UserColor1 == ComputerColor2 || UserColor2 == ComputerColor1 || UserColor2 == ComputerColor2)
            {
                if (UserColor1 == ComputerColor1)
                {
                    Console.WriteLine("0 - 1 You guessed one of the colors correctly at the correct position");
                    GamePlay();
                }
                else if (UserColor2 == ComputerColor2)
                {
                    Console.WriteLine("0 - 1 You guessed one of the colors correctly at the correct position");
                    GamePlay();
                }
                else
                {
                    Console.WriteLine("1 - 0 You guessed one of the colors correctly but not at the correct position");
                    GamePlay();
                }
            }
            else
            {
                Console.WriteLine("0 - 0 You did not guess the correct colors at all");
                GamePlay();
            }
        }
    }
}
