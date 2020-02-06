using System;
using System.Linq;

namespace ticTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tic-Tac-Toe";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Lets play Tic Tac Toe");
            Console.WriteLine("\nWould you like to be X or O");
            currentPlayer = Console.ReadLine().ToUpper();
            int i = 0;
            while (i == 0)
            {
                if (currentPlayer == "X" || currentPlayer == "O")
                {
                    if (currentPlayer == "X")
                    {
                        pcPlayer = "O";
                    }
                    else
                    {
                        pcPlayer = "X";
                    }
                    i++;
                }
                else
                {
                    Console.WriteLine("You did not pick an X or O");
                    Console.WriteLine("\nWould you like to be X or O");
                    currentPlayer = Console.ReadLine().ToUpper();
                }
            }
            Console.Clear();
            PrintBoard();
            PlaceMark();

        }

        static string[][] board = new string[][]
        {
            new string[] {"1", "2", "3"},
            new string[] {"4", "5", "6"},
            new string[] {"7", "8", "9"}
        };
        static string currentPlayer;
        static string pcPlayer;
        static bool noWinner = true;
        static int playCounter;
        static void ChangePlayer()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }
        }
        static void PlaceMark()
        {
            while (noWinner)
            {
                if (currentPlayer == pcPlayer)
                {


                    string[] pcMoves = new string[9 - playCounter]; //create new array
                    int i = 0;
                    int pcCanPlay;
                    //add to pcMoves array only the moves that are left
                    for (int j = 0; j < 3; j++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            if (int.TryParse(board[j][x], out pcCanPlay)) //test for int if pass add to pcMoves
                            {
                                pcMoves[i] = board[j][x];
                                i++; //move to next open array slot
                            }
                        }
                    }

                    //create pc move
                    Random rand = new Random();
                    int index = rand.Next(pcMoves.Length); //pick random move
                    int pickedMove = Convert.ToInt32(pcMoves[index]);
                    switch (pickedMove) //add pc move to board
                    {
                        case 1:
                            board[0][0] = pcPlayer;
                            break;
                        case 2:
                            board[0][1] = pcPlayer;
                            break;
                        case 3:
                            board[0][2] = pcPlayer;
                            break;
                        case 4:
                            board[1][0] = pcPlayer;
                            break;
                        case 5:
                            board[1][1] = pcPlayer;
                            break;
                        case 6:
                            board[1][2] = pcPlayer;
                            break;
                        case 7:
                            board[2][0] = pcPlayer;
                            break;
                        case 8:
                            board[2][1] = pcPlayer;
                            break;
                        case 9:
                            board[2][2] = pcPlayer;
                            break;
                    }
                    Console.Clear();
                    PrintBoard();
                    Console.WriteLine("\nComputer's turn");
                    Console.WriteLine($"The Computer picks: {pcMoves[index]}");
                    System.Threading.Thread.Sleep(2000);
                    HasWon();
                    ChangePlayer();
                }
                else
                {
                    Console.WriteLine("\nPlayer: " + currentPlayer + " - Enter the number where you want to play");
                    string userMove = Console.ReadLine();
                    //int move = Convert.ToInt32(userMove);
                    int move;

                    if (int.TryParse(userMove, out move))
                    {
                        if (move > 9 || move < 1)
                        {
                            Console.WriteLine("You did not enter a number between 1 an 9");
                            PlaceMark();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You did not enter a number between 1 an 9");
                        PlaceMark();
                    }

                    int canPlay;
                    if (move <= 3)
                    {
                        if (int.TryParse(board[0][move - 1], out canPlay))
                        {
                            board[0][move - 1] = currentPlayer;
                            HasWon();
                            ChangePlayer();
                        }
                        else
                        {
                            Console.WriteLine("\nThat square has already been played");
                            PlaceMark();
                        }
                    }
                    else if (move > 3 && move <= 6)
                    {
                        move = move - 3;
                        if (int.TryParse(board[1][move - 1], out canPlay))
                        {
                            board[1][move - 1] = currentPlayer;
                            HasWon();
                            ChangePlayer();
                        }
                        else
                        {
                            Console.WriteLine("\nThat square has already been played");
                            PlaceMark();
                        }
                    }
                    else if (move > 6 && move <= 9)
                    {
                        move = move - 6;
                        if (int.TryParse(board[2][move - 1], out canPlay))
                        {
                            board[2][move - 1] = currentPlayer;
                            HasWon();
                            ChangePlayer();
                        }
                        else
                        {
                            Console.WriteLine("\nThat square has already been played");
                            PlaceMark();
                        }
                    }
                }
            }
        }
        static bool IsHorizonalWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i].GroupBy(x => x).Any(g => g.Count() > 2))
                {
                    string winner = currentPlayer;
                    if (currentPlayer == pcPlayer)
                    {
                        winner = "The Computer";
                    }
                    Console.WriteLine($"\n{winner} Has Won");
                    Console.ReadLine();
                    noWinner = false;
                }
            }

            return true;
        }
        static bool IsVerticalWin()
        {
            string[][] verticalCheck = new string[3][]; //create new array move vertical moves horizonal that way is can use the group by check below
            verticalCheck[0] = new string[3];
            verticalCheck[1] = new string[3];
            verticalCheck[2] = new string[3];

            for (int j = 0; j < 3; j++) //convert board from vertical to horizonal
            {
                for (int x = 0; x < 3; x++)
                {
                    verticalCheck[x][j] = board[j][x];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (verticalCheck[i].GroupBy(x => x).Any(g => g.Count() > 2))
                {
                    string winner = currentPlayer;
                    if (currentPlayer == pcPlayer)
                    {
                        winner = "The Computer";
                    }
                    Console.WriteLine($"\n{winner} Has Won");
                    Console.ReadLine();
                    noWinner = false;
                }
            }
            return true;
        }
        static bool IsDiagonalWin()
        {
            string[][] diagonalCheck = new string[2][]; //create array diag check
            diagonalCheck[0] = new string[3] { board[0][0], board[1][1], board[2][2] };
            diagonalCheck[1] = new string[3] { board[0][2], board[1][1], board[2][0] };

            for (int i = 0; i < 2; i++)
            {
                if (diagonalCheck[i].GroupBy(x => x).Any(g => g.Count() > 2))
                {
                    string winner = currentPlayer;
                    if (currentPlayer == pcPlayer)
                    {
                        winner = "The Computer";
                    }
                    Console.WriteLine($"\n{winner} Has Won");
                    Console.ReadLine();
                    noWinner = false;
                }
            }
            return true;
        }
        static bool HasWon()
        {
            playCounter += 1;
            Console.Clear();
            PrintBoard();
            IsHorizonalWin();
            IsVerticalWin();
            IsDiagonalWin();
            IsTie();
            return true;
        }
        static bool IsTie()
        {
            if (playCounter == 9)
            {
                Console.WriteLine("\nIt is a tie");
                Console.ReadLine();
                noWinner = false;
            }
            return true;
        }
        static void PrintBoard()
        {
            //create board
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + board[0][0] + "  |  " + board[0][1] + "  |  " + board[0][2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + board[1][0] + "  |  " + board[1][1] + "  |  " + board[1][2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  " + board[2][0] + "  |  " + board[2][1] + "  |  " + board[2][2]);
            Console.WriteLine("     |     |");
        }
    }
}
