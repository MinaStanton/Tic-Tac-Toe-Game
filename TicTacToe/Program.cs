using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to Tic, Tac, Toe! \nYou will be X and I will be O.\n");

            bool userContinue = true;
            while (userContinue)
            {
                char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                DisplayBoard(board);
                char player = 'X';
                int selection;
                int gameOver = 0;
                while (gameOver == 0)
                {
                    if (player == 'X')
                    {
                        selection = GetUserSelection(board, "Enter the number of the square you would like to take.");
                        gameOver = SetSquare(board, selection, player);
                        player = 'O';
                    }
                    else
                    {
                        Console.WriteLine("My turn!");
                        selection = RandomGenerateSelection(board);
                        gameOver = SetSquare(board, selection, player);
                        player = 'X';
                    }
                }
                string playAgain = PlayAgain("Would you like to play again? y/n");
                if (playAgain == "n")
                {
                    userContinue = false;
                }

            }
            Console.WriteLine("Thanks for playing!");

        }
        public static string PlayAgain(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower();
            if (input != "y" && input != "n")
            {
                return PlayAgain("Please enter y or n. " + message);
            }
            else
            {
                return input;
            }

        }
        public static int CheckForGameOver(char[] board)
        {
            int outCome = 0;
            bool draw = true;

            if (board[0] == board[1] && board[0] == board[2])//checking first row win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[3] == board[4] && board[3] == board[5])//checking second row win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[6] == board[7] && board[6] == board[8])//checking third row win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[0] == board[3] && board[0] == board[6])//checking first column win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[1] == board[4] && board[1] == board[7])//checking second column win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[2] == board[5] && board[2] == board[8])//checking third column win
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[0] == board[4] && board[0] == board[8])//diagonal
            {
                outCome = 1; //output 1 for winner
            }
            else if (board[2] == board[4] && board[2] == board[6])//diagonal
            {
                outCome = 1; //output 1 for winner
            }
            else
            {
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != 'X' && board[i] != 'O')
                    {
                        draw = false;
                        break;
                    }
                }
                if (draw == true)
                {
                    outCome = 2; //output is a draw
                }
            }
            return outCome;
        }
        public static int SetSquare(char[] board, int selection, char player)
        {
            board[selection] = player;
            DisplayBoard(board);
            int outCome = CheckForGameOver(board);
            if (outCome == 1 && player == 'X')
            {
                Console.WriteLine("You won!");
            }
            else if (outCome == 1 && player == 'O')
            {
                Console.WriteLine("I won!");
            }
            if (outCome == 2)
            {
                Console.WriteLine("Draw!");
            }
            return outCome;
        }
        public static int RandomGenerateSelection(char[] board)
        {
            Random random = new Random();
            int selection = random.Next(0, 8);
            bool notFree = ValidateSelection(board, selection);
            if (notFree == true)
            {
                return RandomGenerateSelection(board);
            }
            else
            {
                return selection;
            }

        }
        public static int GetUserSelection(char[] board, string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            try
            {
                int userSelection = int.Parse(input);
                if (userSelection < 1 || userSelection > 9)
                {
                    return GetUserSelection(board, "Invalid entry!" + message);
                }
                else
                {
                    bool notFree = ValidateSelection(board, userSelection - 1);
                    if (notFree == true)
                    {
                        return GetUserSelection(board, "That space is already taken!" + message);
                    }
                    else
                    {
                        return userSelection - 1;
                    }
                }
            }
            catch
            {
                return GetUserSelection(board, "Invalid entry!" + message);
            }

        }
        public static bool ValidateSelection(char[] board, int selection)
        {
            if (board[selection] == 'X' || board[selection] == 'O')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DisplayBoard(char[] board)
        {
            Console.WriteLine($"\t{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("\t----------");
            Console.WriteLine($"\t{board[6]} | {board[7]} | {board[8]}");
        }
    }
}
