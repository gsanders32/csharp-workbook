using System;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Towers Of Hanoi";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Towers Of Hanoi");
            Console.WriteLine("\nTower of Hanoi is a mathematical puzzle where we have three towers and 4 rings.The objective of the puzzle is to move the entire stack to another tower, obeying the following simple rules:");
            BuildBoard();
            Rules();
            DisplayBoard();
            Play();
        }
        private static Dictionary<string, Stack<int>> GameBoard = new Dictionary<string, Stack<int>>();
        static bool noWinner = true;
        static int counter;
        static void BuildBoard()
        {
            Stack<int> rings = new Stack<int>(); //create stack
            rings.Push(4); //add to stack
            rings.Push(3);
            rings.Push(2);
            rings.Push(1);
            GameBoard.Add("A:", rings); //column and the ring stack
            GameBoard.Add("B:", new Stack<int>());
            GameBoard.Add("C:", new Stack<int>());

        }
        static void DisplayBoard()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in GameBoard)
            {
                Console.Write(item.Key);

                Console.WriteLine(" " + string.Join(" ", item.Value.Reverse())); //display stack in reverse order
            }
            ColorWhite(); //call color change
        }
        static void Rules()
        {
            Console.WriteLine("Rules:");
            Console.WriteLine("\n1) Only one ring can be moved at a time.");
            Console.WriteLine("\n2) Each move consists of taking the upper ring from one of the stacks and placing it on top of another stack i.e. a ring can only be moved if it is the uppermost ring on a stack.");
            Console.WriteLine("\n3) No ring may be placed on top of a smaller ring.\n");
        }
        static void Play()
        {
            do //loop
            {
                string userMover01, userMover02;
                while (true) //loop
                {
                    Console.WriteLine("\nSelect the tower to move from"); 
                    userMover01 = Console.ReadLine().ToUpper();
                    if (userMover01 == "A" || userMover01 == "B" || userMover01 == "C") //check user input
                    {
                        if (GameBoard[userMover01 + ":"].Count == 0) //error check for empty tower
                        {
                            Console.Clear();
                            Rules();
                            DisplayBoard();
                            ColorRed();
                            Console.WriteLine($"\nYou selected an empty tower"); //display error
                            Console.WriteLine($"\nTry again");
                            ColorWhite();
                            Play();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        ColorRed();
                        Console.WriteLine($"\n{userMover01} is not a vaild Tower - Try A, B, or C"); // error not a vaild tower
                        Console.WriteLine($"\nTry again");
                        ColorWhite();
                    }
                }
                while (true)
                {
                    Console.WriteLine("\nSelect the tower to move to");
                    userMover02 = Console.ReadLine().ToUpper();
                    if (userMover02 == "A" || userMover02 == "B" || userMover02 == "C")
                    {
                        if (userMover01 == userMover02) //error tower = tower
                        {
                            Console.Clear();
                            Rules();
                            DisplayBoard();
                            ColorRed();
                            Console.WriteLine($"\nYou can't move from {userMover01} to {userMover02}");//display error
                            ColorWhite();
                            Play();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        ColorRed();
                        Console.WriteLine($"\n{userMover02} is not a vaild Tower - Try A, B, or C");
                        ColorWhite();
                    }
                }
                if (Move(userMover01, userMover02)) //if true call move check
                {
                    ColorRed();
                    Console.WriteLine($"\nYou cannot move {GameBoard[userMover01 + ":"].Peek()} on top of {GameBoard[userMover02 + ":"].Peek()} Please try again!"); //error ring too large
                    ColorWhite();
                    Play();
                }
                else
                {
                    counter += 1; //add to play counter
                    Console.Clear();
                    DisplayBoard();
                    Win(); //call win check
                }
            } while (noWinner);
        }
        static bool Move(string userMove01, string userMove02)
        {
            int move01, move02;
            move01 = GameBoard[userMove01 + ":"].Peek(); //get move01 value will never fail checked in play method 
            try
            {
                move02 = GameBoard[userMove02 + ":"].Peek(); //check if move02 is null
            }
            catch (Exception) //move02 is null commit move
            {
                GameBoard[userMove02 + ":"].Push(move01); //add move01 value to move02 
                GameBoard[userMove01 + ":"].Pop(); //remove value from move02
                return false; 
            }
            if (move01 < move02)
            {
                GameBoard[userMove02 + ":"].Push(move01); //add move01 value to move02 
                GameBoard[userMove01 + ":"].Pop(); //remove value from move02
                return false;
            }
            else
            {
                //return true;
            }

            return true;
        }
        static void Win()
        {
            if (GameBoard["C:"].Count() == 4)
            {
                noWinner = false;
                Console.WriteLine("\nYou Won!!");
                Console.WriteLine($"It took you {counter} moves. The minimum moves required is 15");
                Console.WriteLine("\nWould you like to play again Y/N");
                string userYes = Console.ReadLine().ToLower();
                if (userYes == "y" || userYes == "yes")
                {
                    Console.Clear();
                    noWinner = true;
                    GameBoard.Clear(); //clear dict
                    BuildBoard(); 
                    Rules();
                    DisplayBoard();
                    Play();
                }
                else
                {
                    Console.ReadKey();
                }

            }
        }
        static void ColorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        static void ColorWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
