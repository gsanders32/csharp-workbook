using System;
using System.Collections.Generic;
using System.Text;
using static CheckerV4.Colors;

namespace CheckerV4
{
    class Board
    {
        public List<Checker> checkers;
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++) //create checker list
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Blue, Piece.Single, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Red, Piece.Single, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            }
        }

        public Checker GetChecker(Position pos)
        {
            foreach (var item in checkers)
            {
                if (item.Position.Row == pos.Row && item.Position.Col == pos.Col)
                {
                    return item;
                }
            }
            return null;
        }
        public void RemoveChecker(Checker checker) //remove checker from list
        {
            checkers.Remove(checker);
        }

        public void MoveChecker(Checker fromChecker, Position toPosition) //change checker position
        {
            fromChecker.Position = toPosition;
        }

        public void ChangePiece(Checker fromChecker, Piece type) //change checker to double "King"
        {
            fromChecker.Type = type;
            if (Enum.GetName(typeof(Color), fromChecker.Team) == "Blue")
            {
                int closedSquare = int.Parse("25A0", System.Globalization.NumberStyles.HexNumber);
                fromChecker.Symbol = char.ConvertFromUtf32(closedSquare);
            }
            else if (Enum.GetName(typeof(Colors.Color), fromChecker.Team) == "Red")
            {
                int closedCircle = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                fromChecker.Symbol = char.ConvertFromUtf32(closedCircle);
            }
        }
    }
}
