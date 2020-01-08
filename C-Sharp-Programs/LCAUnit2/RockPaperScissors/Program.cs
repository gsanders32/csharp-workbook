using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            RockPaperScissorsGame();
        }

        public static void RockPaperScissorsGame()
        {
            Console.WriteLine("Let's play Rock Paper Scissors");
            Console.WriteLine("\nRules:");
            Console.WriteLine("Rule 1: Rock beats Scissors");
            Console.WriteLine("Rule 2: Scissors beats Paper");
            Console.WriteLine("Rule 3: Paper beats Rock");
            Console.WriteLine("Rule 4: It is a tie if the players make the same choice");
            Console.WriteLine("\nEnter 1 Rock, Enter 2 Paper, and Enter 3 for Scissors");

            int keepPlaying = 0;

            int gamesPlayed = 0;
            int userWin = 0;
            int computerWin = 0;
            int ties = 0;

            while (keepPlaying == 0)
            {
                int user = UserHand();
                int computer = ComputerHand();

                if (user == computer)
                {
                    Console.WriteLine("It's a TIE!");
                    ties++;
                    keepPlaying = Again();
                }
                else if (user == 1) //user = Rock
                {
                    if (computer == 3) //computer = Scissors
                    {
                        Console.WriteLine("You Win");
                        userWin++;
                        keepPlaying = Again();
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won");
                        computerWin++;
                        keepPlaying = Again();
                    }
                }
                else if (user == 2) //user = Paper
                {
                    if (computer == 1) //computer = Rock
                    {
                        Console.WriteLine("You Win");
                        userWin++;
                        keepPlaying = Again();
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won");
                        computerWin++;
                        keepPlaying = Again();
                    }
                }
                else if (user == 3) //user = Scissors
                {
                    if (computer == 2) //computer = Paper
                    {
                        Console.WriteLine("You Win");
                        userWin++;
                        keepPlaying = Again();
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won");
                        computerWin++;
                        keepPlaying = Again();
                    }
                }
                gamesPlayed++;
                Console.WriteLine("\nTotal Games Played: "+gamesPlayed+" Scoreboard - You: "+userWin+" Computer: "+computerWin+" Ties: "+ties);

            }
        }

        public static int UserHand()
        {

            Console.WriteLine("\nPick your weapon");
            string userInput = Console.ReadLine();
            int user;
            int i = 0;
            while (i == 0)
            {
                try
                {
                    user = Convert.ToInt32(userInput);
                    if (user > 0 && user < 4)
                    {
                        i++;
                    }
                    else
                    {
                        string fail = "Fail";
                        user = Convert.ToInt32(fail);
                    }
                }
                catch
                {
                    Console.WriteLine("You did not enter a 1, 2, or3");
                    Console.WriteLine("Try again");
                    userInput = Console.ReadLine();
                }
            }
            user = Convert.ToInt32(userInput);
            return user;

        }

        public static int ComputerHand()
        {
            Random generator = new Random();
            // creates a number 0,1 or 2
            int randomNumber = generator.Next(0, 3);
            return randomNumber;
        }

        public static int Again()
        {
            Console.WriteLine("Would like to play again? Enter Yes or No?");
            string userinput = Console.ReadLine();
            userinput = userinput.ToLower();
            if (userinput == "yes" || userinput == "y" || userinput == "1" || userinput == "2" || userinput == "3")
            {
                Console.Clear();
                Console.WriteLine("\nEnter 1 Rock, Enter 2 Paper, and Enter 3 for Scissors");
                return 0;
            }
            else
            {
                return 1;
            }

        }
    }
}
