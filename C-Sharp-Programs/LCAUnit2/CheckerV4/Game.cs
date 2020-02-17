using System;
using System.Collections.Generic;
using System.Text;
using static CheckerV4.Colors;

namespace CheckerV4
{
    class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }
        string[][][] boardGrid = new string[8][][];
        //string playerTeam = "Red"; //testing
        string error;
        string playerTeam;
        bool noWinner = true;
        Checker fromChecker = new Checker();
        Checker toChecker = new Checker();
        Checker jumpChecker = new Checker();
        Position fromPosition = new Position();
        Position toPosition = new Position();
        public void Start()
        {
            //Play(); // bypass questions for testing
            Console.Write("Welcome to Checkers - Would you like to see the Rules -");
            Change(Color.Green);
            Console.WriteLine(" Yes/No");
            Change(Color.White);
            string seeRules = Console.ReadLine().Trim().ToLower();
            if (seeRules == "y" || seeRules == "yes")
            {
                Rules.Display();
            }
            Console.Write("Are you ready to play?");
            Change(Color.Green);
            Console.WriteLine(" Yes/No");
            Change(Color.White);
            string userReady = Console.ReadLine().Trim().ToLower();
            if (userReady == "y" || userReady == "yes")
            {
                TeamColor();
                Play();
            }
            else
            {
                Console.Clear();
                Change(Color.Red);
                Console.WriteLine("Goodbye!");
                Console.Read();
            }
        }
        public void Play()
        {
            do
            {
                Console.Clear();
                DisplayBoard();
                CurrentTeamColor(playerTeam);
                Console.WriteLine($"{playerTeam}'s turn");
                Change(Color.Red);
                Console.WriteLine(error);
                Change(Color.White);
                TestInputFrom();
                TestInputTo();
                TestMove();
            } while (noWinner);

        }
        public void DisplayBoard()
        {
            int cellCount = 1;
            //string[][][] boardGrid = new string[8][][];
            for (int i = 0; i < 8; i++)
            {
                boardGrid[i] = new string[8][];
                for (int j = 0; j < 8; j++)
                {
                    foreach (var item in board.checkers)
                    {
                        if (item.Position.Row == i && item.Position.Col == j)//if checker add with cellCount
                        {
                            boardGrid[i][j] = new string[4] { cellCount.ToString(), Enum.GetName(typeof(Color), item.Team), Enum.GetName(typeof(Piece), item.Type), item.Symbol };
                            break;
                        }
                        else // if no checker just add cell count
                        {
                            boardGrid[i][j] = new string[4] { cellCount.ToString(), null, null, null };
                        }
                    }
                    cellCount += 1;
                }
            }
            for (int i = 0; i < 48; i++)//top of board
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int row = 0; row < 8; row++) //loop creates 8 rows
            {
                for (int col = 0; col < 8; col++) //loop creates 8 cols for cell number
                {
                    //display cell number checking cell number to change spaing so the borad looks nice
                    if (Convert.ToInt32(boardGrid[row][col][0]) < 10)
                    {
                        Console.Write($"|");
                        Change(Color.Green);
                        Console.Write($"{boardGrid[row][col][0]}    ");
                        Change(Color.White);
                    }
                    else
                    {
                        Console.Write($"|");
                        Colors.Change(Colors.Color.Green);
                        Console.Write($"{boardGrid[row][col][0]}   ");
                        Colors.Change(Colors.Color.White);
                    }

                }
                Console.WriteLine("|"); // close row
                for (int col = 0; col < 8; col++)
                {
                    if (boardGrid[row][col][1] != null) // check for peice
                    {
                        if (boardGrid[row][col][1] == "Blue")// change color of peices
                        {
                            Console.Write($"|  ");
                            Change(Color.Blue);
                            Console.Write($"{boardGrid[row][col][3]}  ");
                            Change(Color.White);
                        }
                        else if (boardGrid[row][col][1] == "Red")// change color of peices
                        {
                            Console.Write($"|  ");
                            Change(Color.Red);
                            Console.Write($"{boardGrid[row][col][3]}  ");
                            Change(Color.White);
                        }
                    }
                    else //no peice to place
                    {
                        Console.Write("|     ");
                    }
                }
                Console.WriteLine("|"); // close row
                for (int i = 0; i < 8; i++) //add row gap
                {
                    Console.Write("|_____");
                }
                Console.WriteLine("|");
            }
        }
        void TeamColor()
        {
            bool playerPicked = false;
            do
            {
                Console.WriteLine("What color do you want to be? Red/Blue");
                string userColorPick = Console.ReadLine().Trim().ToLower();
                if (userColorPick == "r" || userColorPick == "red" || userColorPick == "b" || userColorPick == "blue")
                {
                    switch (userColorPick)
                    {
                        case "r":
                        case "red":
                            playerTeam = "Red";
                            playerPicked = true;
                            break;
                        case "b":
                        case "blue":
                            playerTeam = "Blue";
                            playerPicked = true;
                            break;
                    }
                }
                else
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not select a color?");
                    Change(Color.White);
                }
            } while (!playerPicked);

        }
        void ChangeTeam()
        {
            playerTeam = playerTeam == "Red" ? "Blue" : "Red";
        }
        void TestInputFrom()
        {
            bool movePass = false;
            do
            {
                Console.Write("Please select the Checker you want to move. Use the number in ");
                Change(Color.Green);
                Console.WriteLine("GREEN");
                Change(Color.White);
                string userFrom = Console.ReadLine().Trim();
                int moveNum;
                if (int.TryParse(userFrom, out moveNum))
                {
                    if (moveNum >= 1 && moveNum <= 64)
                    {
                        string[] test = new string[3];
                        for (int row = 0; row < 8; row++)
                        {
                            for (int col = 0; col < 8; col++)
                            {
                                if (Convert.ToInt32(boardGrid[row][col][0]) == moveNum)
                                {
                                    fromPosition = new Position(row, col);
                                    fromChecker = board.GetChecker(fromPosition);
                                    col = 8;
                                    break;
                                }
                            }
                        }
                        if (fromChecker != null)
                        {
                            if (Enum.GetName(typeof(Colors.Color), fromChecker.Team) == playerTeam)
                            {
                                movePass = true;
                            }
                            else
                            {
                                Change(Color.Red);
                                Console.WriteLine("You can not select the opponent's checkers");
                                Change(Color.White);
                            }
                        }
                        else
                        {
                            Change(Color.Red);
                            Console.WriteLine("You did not select a Checker! Try again");
                            Change(Color.White);
                        }
                    }
                    else
                    {
                        Change(Color.Red);
                        Console.WriteLine("You must select a number between 1 and 64");
                        Change(Color.White);
                    }
                }
                else
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not enter a number");
                    Change(Color.White);
                }
            } while (!movePass);

        }
        void TestInputTo()
        {
            bool movePass = false;
            do
            {
                Console.Write("Please select the cell you want to move to. Use the number in ");
                Change(Color.Green);
                Console.WriteLine("GREEN");
                Change(Color.White);
                string userTo = Console.ReadLine().Trim();
                int moveNum;
                if (int.TryParse(userTo, out moveNum))
                {
                    if (moveNum >= 1 && moveNum <= 64)
                    {
                        string[] test = new string[3];
                        for (int row = 0; row < 8; row++)
                        {
                            for (int col = 0; col < 8; col++)
                            {
                                if (Convert.ToInt32(boardGrid[row][col][0]) == moveNum)
                                {
                                    toPosition = new Position(row, col);
                                    toChecker = board.GetChecker(toPosition);
                                    row = 8;
                                    break;
                                }
                            }
                        }
                        if (toChecker == null)
                        {
                            movePass = true;
                        }
                        else
                        {
                            Change(Color.Red);
                            Console.WriteLine("You did not select a Empty Cell Try again");
                            Change(Color.White);
                        }
                    }
                    else
                    {
                        Change(Color.Red);
                        Console.WriteLine("You must select a number between 1 and 64");
                        Change(Color.White);
                    }
                }
                else
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not enter a number");
                    Change(Color.White);
                }
            } while (!movePass);
        }
        void TestMove()
        {
            string opponentColor = playerTeam == "Red" ? "Blue" : "Red";
            int pieceSingleRowMove1 = playerTeam == "Red" ? 1 : -1;
            int pieceSingleRowMove2 = playerTeam == "Red" ? 2 : -2;
            if (fromChecker.Type == Piece.Single)
            {
                if (fromChecker.Position.Row - toPosition.Row == pieceSingleRowMove1) //-1 if blue 1 if red
                {
                    if (fromChecker.Position.Col - toPosition.Col == 1 || fromChecker.Position.Col - toPosition.Col == -1) //check move left of right by 1
                    {
                        error = string.Empty;
                        MakeMove();
                    }
                    else // did not move left or right by 1
                    {
                        error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]}";
                    }
                }
                else if (fromChecker.Position.Row - toPosition.Row == pieceSingleRowMove2) // jump move
                {
                    int col;
                    int row = fromChecker.Position.Row - pieceSingleRowMove1; // get jumped row

                    if (fromChecker.Position.Col - toPosition.Col < pieceSingleRowMove1) // find the out if the move was left or right
                    {
                        col = toPosition.Col - 1; // move was right
                    }
                    else
                    {
                        col = toPosition.Col + 1; //move was left
                    }
                    Position opponentPos = new Position(row, col); // position
                    jumpChecker = board.GetChecker(opponentPos); //get checker player is jumping
                    if (jumpChecker != null) //see if player jumped empty cell
                    {
                        if ((fromChecker.Position.Col - toPosition.Col == 2 || fromChecker.Position.Col - toPosition.Col == -2) && Enum.GetName(typeof(Color), jumpChecker.Team) == opponentColor)
                        {
                            error = string.Empty;
                            board.RemoveChecker(jumpChecker);
                            MakeMove();

                        }
                        else //trying to jump their own piece
                        {
                            error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]} you can't jump your own piece";
                        }
                    }
                    else //player tried to jump empty cell
                    {
                        error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]} there was no Opponent to Jump!";
                    }
                }
                else //player did not move 1 or 2 rows
                {
                    error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]}";
                }
            }
            else if (fromChecker.Type == Piece.Double)
            {
                if (fromChecker.Position.Row - toPosition.Row == 1 || fromChecker.Position.Row - toPosition.Row == -1) //-1 if blue 1 if red
                {
                    if (fromChecker.Position.Col - toPosition.Col == 1 || fromChecker.Position.Col - toPosition.Col == -1) //check move left of right by 1
                    {
                        error = string.Empty;
                        MakeMove();
                    }
                    else // did not move left or right by 1
                    {
                        error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]}";
                    }
                }
                else if (fromChecker.Position.Row - toPosition.Row == 2 || fromChecker.Position.Row - toPosition.Row == -2) // jump move
                {
                    int row, col;
                    if (fromChecker.Position.Row - toPosition.Row < pieceSingleRowMove1) // find if move is up or down
                    {
                        row = fromChecker.Position.Row + 1;
                    }
                    else
                    {
                        row = fromChecker.Position.Row - 1;
                    }
                    if (fromChecker.Position.Col - toPosition.Col < pieceSingleRowMove1) // find the out if the move was left or right
                    {
                        col = toPosition.Col - 1; // move was right
                    }
                    else
                    {
                        col = toPosition.Col + 1; //move was left
                    }
                    Position opponentPos = new Position(row, col); // position
                    jumpChecker = board.GetChecker(opponentPos); //get checker player is jumping
                    if (jumpChecker != null) //see if player jumped empty cell
                    {
                        if ((fromChecker.Position.Col - toPosition.Col == 2 || fromChecker.Position.Col - toPosition.Col == -2) && Enum.GetName(typeof(Color), jumpChecker.Team) == opponentColor)
                        {
                            error = string.Empty;
                            board.RemoveChecker(jumpChecker);
                            MakeMove();

                        }
                        else //trying to jump their own piece
                        {
                            error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]} you can't jump your own piece";
                        }
                    }
                    else //player tried to jump empty cell
                    {
                        error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]} there was no Opponent to Jump!";
                    }
                }
                else //player did not move 1 or 2 rows
                {
                    error = $"You cant Move to cell {boardGrid[toPosition.Row][toPosition.Col][0]}";
                }
            }
        }
        void MakeMove()
        {
            board.MoveChecker(fromChecker, toPosition);
            CheckKing();
            CheckWin();
            ChangeTeam();
        }
        void CheckKing()
        {
            int rowNum = playerTeam == "Red" ? 0 : 7; //get row to test

            if (toPosition.Row == rowNum)
            {
                if (fromChecker.Type == Piece.Single) // check if piece is single
                {
                    board.ChangePiece(fromChecker, Piece.Double);
                }
            }
        }
        void CheckWin()
        {
            string opponentColor = playerTeam == "Red" ? "Blue" : "Red";
            int count = 0;
            foreach (var item in board.checkers)
            {
                string test = Enum.GetName(typeof(Colors.Color), item.Team);
                if (test == opponentColor)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                noWinner = false;
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"{playerTeam} Wins!!");
                Console.Read();
            }
        }
    }
}
