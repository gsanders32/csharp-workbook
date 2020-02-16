using System;
using System.Collections.Generic;
using System.Text;
using static CheckerV4.Colors;

namespace CheckerV4
{
    public enum Piece { Single = 0, Double = 1 }
    public struct Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        
        public Position( int row, int col)
        {
            
            this.Row = row;
            this.Col = col;
        }
    }

    public class Checker
    {
        public string Symbol { get; set; }
        public Color Team { get; private set; }
        public Piece Type { get;  set; }
        public Position Position { get; set; }

        public Checker() //empty checker
        {

        }
        public Checker(Color team, Piece type, int row, int col) //create full checker
        {
            this.Team = team;
            this.Type = type;
            Position = new Position(row, col);
            if (Enum.GetName(typeof(Color), team) == "Blue")
            {
                if (Enum.GetName(typeof(Piece), type) == "Single")
                {
                    int openSquare = int.Parse("25A1", System.Globalization.NumberStyles.HexNumber);
                    Symbol = char.ConvertFromUtf32(openSquare);
                }
                else if (Enum.GetName(typeof(Piece), type) == "Double")
                {
                    int closedSquare = int.Parse("25A0", System.Globalization.NumberStyles.HexNumber);
                    Symbol = char.ConvertFromUtf32(closedSquare);
                }
            }
            else if (Enum.GetName(typeof(Colors.Color), team) == "Red")
            {
                if (Enum.GetName(typeof(Piece), type) == "Single")
                {
                    int openCircle = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                    Symbol = char.ConvertFromUtf32(openCircle);
                }
                else if (Enum.GetName(typeof(Piece), type) == "Double")
                {
                    int closedCircle = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                    Symbol = char.ConvertFromUtf32(closedCircle);
                }
            }
        }
    }
}
