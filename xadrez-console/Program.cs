using System;
using GameBoard;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Gameboard board = new Gameboard(8, 8);

            Screen.PrintGameboard(board);
        }
    }
}
