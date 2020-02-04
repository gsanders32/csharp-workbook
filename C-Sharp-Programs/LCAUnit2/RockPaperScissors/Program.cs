using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            RockPaperScissorsGame(); //call method 
        }

        public static void RockPaperScissorsGame()
        {
            Console.WriteLine("Let's play Rock Paper Scissors"); //display text
            Console.WriteLine("\nRules:"); //display text
            Console.WriteLine("Rule 1: Rock beats Scissors"); //display text
            Console.WriteLine("Rule 2: Scissors beats Paper"); //display text
            Console.WriteLine("Rule 3: Paper beats Rock"); //display text
            Console.WriteLine("Rule 4: It is a tie if the players make the same choice"); //display text
            Console.WriteLine("\nEnter 1 Rock, Enter 2 Paper, and Enter 3 for Scissors"); //display text

            int keepPlaying = 0; //create var and set to zero
            int gamesPlayed = 0; //create var and set to zero
            int userWin = 0; //create var and set to zero
            int computerWin = 0; //create var and set to zero
            int ties = 0; //create var and set to zero

            while (keepPlaying == 0) //run while keepPlaying equals zero
            {
                int user = UserHand(); //call method
                int computer = ComputerHand(); //call method

                if (user == computer) //check for tie
                {
                    Console.WriteLine("It's a TIE!"); //display text
                    ties++; //add one to the tie count
                }
                else if (user == 1) //user = Rock
                {
                    if (computer == 3) //computer = Scissors
                    {
                        Console.WriteLine("You Win"); //display text
                        userWin++; //add one to the userWin count
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won"); //display text
                        computerWin++; //add one to the computerWin count
                    }
                }
                else if (user == 2) //user = Paper
                {
                    if (computer == 1) //computer = Rock
                    {
                        Console.WriteLine("You Win"); //display text
                        userWin++; //add one to the userWin count
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won"); //display text
                        computerWin++; //add one to the computerWin count
                    }
                }
                else if (user == 3) //user = Scissors
                {
                    if (computer == 2) //computer = Paper
                    {
                        Console.WriteLine("You Win"); //display text
                        userWin++; //add one to the userWin count
                    }
                    else
                    {
                        Console.WriteLine("The Computer Won"); //display text
                        computerWin++; //add one to the computerWin count
                    }
                }
                keepPlaying = Again(); //call method
                gamesPlayed++; //add one to the gamesPlayed count

                //display text show scoreboard totals
                Console.WriteLine("\nTotal Games Played: " + gamesPlayed + " Scoreboard - You: " + userWin + " Computer: " + computerWin + " Ties: " + ties);
            }
        }

        public static int UserHand()
        {
            Console.WriteLine("\nPick your weapon"); //display text
            string userInput = Console.ReadLine(); //get user input
            int user =0; //create var an set to zero
            int i = 0; //create var an set to zero
            while (i == 0) //run while i is equal to zero
            {
                try //test
                {
                    user = Convert.ToInt32(userInput); //check if num
                    if (user > 0 && user < 4) //check input is greater than zero and less than 4
                    {
                        i++; //add one to i
                    }
                    else
                    {
                        string fail = "Fail"; //create string var
                        user = Convert.ToInt32(fail); //force fail
                    }
                }
                catch //fail
                {
                    Console.WriteLine("You did not enter a 1, 2, or 3"); //display text
                    Console.WriteLine("Try again"); //display text
                    userInput = Console.ReadLine(); //get user input
                }
            }
            user = Convert.ToInt32(userInput); //convert to int
            return user; //return int

        }

        public static int ComputerHand()
        {
            Random generator = new Random();
            // creates a number 1, 2 or 3
            int randomNumber = generator.Next(1, 3);
            return randomNumber;
        }

        public static int Again()
        {
            Console.WriteLine("Would like to play again? Enter Yes or No?"); //display text
            string userinput = Console.ReadLine(); //get user input
            userinput = userinput.ToLower(); //convert text to lower case
            if (userinput == "yes" || userinput == "y" ) //check if user wants to play again
            {
                Console.Clear(); //clear the console screen
                Console.WriteLine("\nEnter 1 Rock, Enter 2 Paper, and Enter 3 for Scissors"); //display text
                return 0; //return int
            }
            else
            {
                return 1; //return int
            }
        }
    }
}
