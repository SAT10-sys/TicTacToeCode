using System;

namespace Tic_Tac_Toe_Game_Code
{
    public class TicTacToeGame
    {
        public const int HEAD = 0;
        public const int TAIL = 1;
        public enum Player { USER,COMPUTER};
        static void Main(string[] args)
        {
            char[] board = createBoard();
            displayBoard(board);
            Player player = FirstMovement();
            char playerCharacter = ChooseLetter();
            int userMovement = Movement(board);
            CheckSpace(board, userMovement, playerCharacter);
            Console.WriteLine(" Check if won: " + CheckWinner(board, playerCharacter));
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
        private static Player FirstMovement()
        {
            int toss = selectRandomChoices(2);
            return (toss == HEAD) ? Player.USER : Player.COMPUTER;
        }
        private static int selectRandomChoices(int choices)
        {
            Random random = new Random();
            return (int)(random.Next() * 10) % choices;
        }
        private static bool CheckWinner(char[] b, char ch)
        {
            return ((b[1]==ch&&b[2]==ch&&b[3]==ch)||(b[4]==ch&&b[5]==ch&&b[6]==ch)||(b[7]==ch&&b[8]==ch&&b[9]==ch)||(b[1]==ch&&b[4]==ch&&b[7]==ch)||(b[2]==ch&&b[5]==ch&&b[8]==ch)||(b[3]==ch&&b[6]==ch&&b[9]==ch)||(b[1]==ch&&b[5]==ch&&b[9]==ch)||(b[3]==ch&&b[5]==ch&&b[7]==ch));
        }
    }
}
