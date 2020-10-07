using System;

namespace Tic_Tac_Toe_Game_Code
{
    public class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = createBoard();
            displayBoard(board);
            char playerCharacter = ChooseLetter();
            int userMovement = Movement(board);
            CheckSpace(board, userMovement, playerCharacter);
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
        private static int Movement(char[] board)
        {
            int[] indices = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            while(true)
            {
                Console.WriteLine(" Choose your move ");
                int position = Convert.ToInt32(Console.ReadLine());
                if (Array.Find<int>(indices, element => element == position) != 0 && isEligible(board, position))
                    return position;
            }
        }
        private static bool isEligible(char[] board, int position)
        {
            return board[position] == ' ';
        }
        private static void CheckSpace(char[] board, int position, char playerCharacter)
        {
            bool freeSpace = isEligible(board, position);
            if (freeSpace)
                board[position] = playerCharacter;
        }
    }
}
