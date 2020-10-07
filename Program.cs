using System;

namespace Tic_Tac_Toe_Game_Code
{
    public class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
            char playerCharacter = ChooseLetter();
        }
        private static char[] createBoard()
        {
            char[] board = new char[10];
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';
            return board;
        }
        private static char ChooseLetter()
        {
            Console.WriteLine(" Choose Letter between X and 0 ");
            string playerCharacter = Console.ReadLine();
            return char.ToUpper(playerCharacter[0]);
        }
    }
}
