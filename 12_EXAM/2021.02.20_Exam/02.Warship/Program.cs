using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warship
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attacs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            char[,] field = new char[n, n];
            int AShips = 0;
            int BShips = 0;
            int totalShipsLost = 0;
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char[] currCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currCol[col];
                    if (field[row, col] == '<')
                    {
                        AShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        BShips++;
                    }
                }
            }
            int player = 0;
            while (attacs.Count != 0)
            {
                if (AShips == 0 || BShips == 0)
                {
                    break;
                }
                int[] coordinates = attacs[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (IsPositionValid(row, col, n, n))
                {
                    if (field[row, col] == '#')
                    {
                        if (IsPositionValid(row - 1, col - 1, n, n))
                        {
                            if (field[row - 1, col - 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col - 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col - 1] = 'X';
                        }
                        if (IsPositionValid(row - 1, col, n, n))
                        {
                            if (field[row - 1, col] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col] = 'X';
                        }
                        if (IsPositionValid(row - 1, col + 1, n, n))
                        {
                            if (field[row - 1, col + 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col + 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col + 1] = 'X';
                        }
                        if (IsPositionValid(row, col - 1, n, n))
                        {
                            if (field[row, col - 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row, col - 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row, col - 1] = 'X';
                        }
                        if (IsPositionValid(row, col + 1, n, n))
                        {
                            if (field[row, col + 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row, col + 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row, col + 1] = 'X';
                        }
                        if (IsPositionValid(row + 1, col - 1, n, n))
                        {
                            if (field[row + 1, col - 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col - 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col - 1] = 'X';
                        }
                        if (IsPositionValid(row + 1, col, n, n))
                        {
                            if (field[row + 1, col ] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col ] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col] = 'X';
                        }
                        if (IsPositionValid(row + 1, col + 1, n, n))
                        {
                            if (field[row + 1, col + 1] == '<')
                            {
                                AShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col + 1] == '>')
                            {
                                BShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col + 1] = 'X';
                        }
                    }
                    else if (player % 2 == 0 && field[row, col] != '<')
                    {
                        field[row, col] = 'X';
                        BShips--;
                        totalShipsLost++;
                    }
                    else if (player % 2 != 0 && field[row, col] != '>')
                    {
                        field[row, col] = 'X';
                        AShips--;
                        totalShipsLost++;
                    }

                }

                attacs.RemoveAt(0);
            }

            if (AShips > 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsLost} ships have been sunk in the battle.");
            }
            else if (BShips > 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsLost} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {AShips} left. Player Two has {BShips} left.");
            }
        }
        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
