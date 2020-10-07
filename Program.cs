using System;

namespace Tic_Tac_Toe_Game_Code
{
    public class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
        }
        private static char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';
            return board;
        }
    }
}
