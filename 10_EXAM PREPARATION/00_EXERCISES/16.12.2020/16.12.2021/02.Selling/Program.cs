using System;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int sRow = 0;
            int sCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            int money = 0;
            bool gotOut = false;

            while (money < 50)
            {
                string movement = Console.ReadLine();
                matrix[sRow, sCol] = '-';
                int nextRow = MoveRow(sRow, movement);
                int nextCol = MoveCol(sCol, movement);

                if (!IsPositionValid(nextRow, nextCol, n, n))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    matrix[sRow, sCol] = '-';
                    gotOut = true;
                    break;
                }

                if (char.IsDigit(matrix[nextRow, nextCol]))
                {
                    money += int.Parse(matrix[nextRow, nextCol].ToString());
                    matrix[nextRow, nextCol] = 'S';
                    sRow = nextRow;
                    sCol = nextCol;
                }
                else if (matrix[nextRow, nextCol] == 'O')
                {
                    matrix[nextRow, nextCol] = '-';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                matrix[row, col] = 'S';
                                sRow = row;
                                sCol = col;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    matrix[nextRow, nextCol] = 'S';
                    sRow = nextRow;
                    sCol = nextCol;
                }
            }
            if (!gotOut)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
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
