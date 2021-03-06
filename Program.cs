﻿using System;

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
            char computerCharacter = (playerCharacter == 'X') ? '0' : 'X';
            int userMovement = Movement(board);
            CheckSpace(board, userMovement, playerCharacter);
            Console.WriteLine(" Check if won: " + CheckWinner(board, playerCharacter));
            int computerMove = getComputerMove(board, computerCharacter, playerCharacter);
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
        private static int getComputerMove(char[] board, char computerCharacter, char playerCharacter)
        {
            int winningMove = getWinningMove(board, computerCharacter);
            if (winningMove != 0)
                return winningMove;
            int playerMove = getWinningMove(board, playerCharacter);
            if (playerMove != 0)
                return playerMove;
            int[] cornerIndices = { 1, 3, 7, 9 };
            int compMove = getRandomMove(board, cornerIndices);
            if (compMove != 0)
                return compMove;
            if (isEligible(board, 5))
                return 5;
            int[] sideIndices = { 2, 4, 6, 8 };
            compMove = getRandomMove(board, sideIndices);
            if (compMove != 0)
                return compMove;
            return 0;
        }
        private static int getWinningMove(char[] board, char letter)
        {
            for(int i=1;i<board.Length;i++)
            {
                char[] copyOfBoard = getCopyOfBoard(board);
                if(isEligible(copyOfBoard,i))
                {
                    CheckSpace(copyOfBoard, i, letter);
                }
                if(CheckWinner(copyOfBoard, letter))
                {
                    return i;
                }
            }
            return 0;
        }
        private static char[] getCopyOfBoard(char[] board)
        {
            char[] boardCopy = new char[10];
            return boardCopy;
        }
        private static int getRandomMove(char[] board, int[] moves)
        {
            for(int i=0;i<moves.Length;i++)
            {
                if (isEligible(board, moves[i]))
                    return moves[i];
            }
            return 0;
        }
    }
}
