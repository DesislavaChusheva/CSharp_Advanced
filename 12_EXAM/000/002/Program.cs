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
            List<string> attacs = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            char[,] field = new char[n, n];
            int aShips = 0;
            int bShips = 0;
            int totalShipsLost = 0;
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                List<char> currCol = input.ToList();
                for (int i = 0; i < currCol.Count; i++)
                {
                    if (currCol[i] == ' ')
                    {
                        currCol.RemoveAt(i);
                    }
                }
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currCol[col];
                    if (field[row, col] == '<')
                    {
                        aShips++;
                    }
                    else if (field[row, col] == '>')
                    {
                        bShips++;
                    }
                }
            }

            int player = 0;
            while (attacs.Count != 0)
            {
                if (aShips == 0 || bShips == 0)
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
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col - 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col - 1] = 'X';
                        }
                        if (IsPositionValid(row - 1, col, n, n))
                        {
                            if (field[row - 1, col] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col] = 'X';
                        }
                        if (IsPositionValid(row - 1, col + 1, n, n))
                        {
                            if (field[row - 1, col + 1] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row - 1, col + 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row - 1, col + 1] = 'X';
                        }
                        if (IsPositionValid(row, col - 1, n, n))
                        {
                            if (field[row, col - 1] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row, col - 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row, col - 1] = 'X';
                        }
                        if (IsPositionValid(row, col + 1, n, n))
                        {
                            if (field[row, col + 1] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row, col + 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row, col + 1] = 'X';
                        }
                        if (IsPositionValid(row + 1, col - 1, n, n))
                        {
                            if (field[row + 1, col - 1] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col - 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col - 1] = 'X';
                        }
                        if (IsPositionValid(row + 1, col, n, n))
                        {
                            if (field[row + 1, col] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col] = 'X';
                        }
                        if (IsPositionValid(row + 1, col + 1, n, n))
                        {
                            if (field[row + 1, col + 1] == '<')
                            {
                                aShips--;
                                totalShipsLost++;
                            }
                            else if (field[row + 1, col + 1] == '>')
                            {
                                bShips--;
                                totalShipsLost++;
                            }
                            field[row + 1, col + 1] = 'X';
                        }
                    }
                    else if (player % 2 == 0 && field[row, col] == '>')
                    {
                        field[row, col] = 'X';
                        bShips--;
                        totalShipsLost++;
                    }
                    else if (player % 2 != 0 && field[row, col] == '<')
                    {
                        field[row, col] = 'X';
                        aShips--;
                        totalShipsLost++;
                    }

                }
                player++;
                attacs.RemoveAt(0);
            }
            if ((aShips > 0 && bShips > 0) || (aShips == 0 && bShips == 0))
            {
                Console.WriteLine($"It's a draw! Player One has {aShips} ships left. Player Two has {bShips} ships left.");
            }
            else if (aShips > 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShipsLost} ships have been sunk in the battle.");
            }
            else if (bShips > 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShipsLost} ships have been sunk in the battle.");
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
