using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBoard
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityOfMovesMade { get; protected set; }
        public Gameboard Board { get; protected set; }

        public Piece(Position position, Color color, Gameboard board)
        {
            Position = position;
            Color = color;
            Board = board;
            QuantityOfMovesMade = 0;
        }
    }
}
