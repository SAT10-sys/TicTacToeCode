using System;

namespace Tic_Tac_Toe_Game_Code
{
    public class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
            char playerCharacter = ChooseLetter();
            displayBoard(board);
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
        private static void displayBoard(char[] board)
        {
            Console.WriteLine("\n" + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine(" ------------------------ ");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine(" ------------------------ ");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }
    }
}
