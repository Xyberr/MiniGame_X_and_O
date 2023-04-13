using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static bool gameover = false;
        static char player = 'X';

        static void Main(string[] args)
        {
            InitializeBoard();
            while (!gameover)
            {
                DrawBoard();
                Console.WriteLine($"Player {player}, enter row and column: ");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                if (board[row, col] == '-')
                {
                    board[row, col] = player;
                    if (CheckWin())
                    {
                        Console.WriteLine($"Player {player} wins!");
                        gameover = true;
                    }
                    else if (CheckTie())
                    {
                        Console.WriteLine("Tie game!");
                        gameover = true;
                    }
                    else
                    {
                        player = (player == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("That space is already taken, please try again.");
                }
            }
            Console.ReadLine();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("   0  1  2 ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckWin()
        {
            // check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }
            // check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != '-' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true;
                }
            }
            // check diagonals
            if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }
            return false;
        }

        static bool CheckTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}