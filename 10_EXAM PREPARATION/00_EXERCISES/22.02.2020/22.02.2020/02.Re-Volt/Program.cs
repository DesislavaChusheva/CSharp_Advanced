using System;
using System.Linq;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int fRow = 0;
            int fCol = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                }
            }
            bool lost = true;
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();
                int nextRow = MoveRow(fRow, command);
                int nextCol = MoveCol(fCol, command);
                int[] nextCoordinates = Coordinates(nextRow, nextCol, n, n);
                nextRow = nextCoordinates[0];
                nextCol = nextCoordinates[1];

                matrix[fRow, fCol] = '-';

                if (matrix[nextRow, nextCol] == '-')
                {
                    matrix[nextRow, nextCol] = 'f';
                    fRow = nextRow;
                    fCol = nextCol;
                    continue;
                }
                if (matrix[nextRow, nextCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[nextRow, nextCol] = 'f';
                    matrix[fRow, fCol] = '-';
                    lost = false;
                    break;
                }
                if (matrix[nextRow, nextCol] == 'B')
                {
                    int secondNextRow = MoveRow(nextRow, command);
                    int secondNextCol = MoveCol(nextCol, command);
                    int[] secondNextCoordinates = Coordinates(secondNextRow, secondNextCol, n, n);
                    secondNextRow = secondNextCoordinates[0];
                    secondNextCol = secondNextCoordinates[1];

                    matrix[fRow, fCol] = '-';
                    matrix[secondNextRow, secondNextCol] = 'f';
                    fRow = secondNextRow;
                    fCol = secondNextCol;
                    continue;
                }
                if (matrix[nextRow, nextCol] == 'T')
                {
                    matrix[fRow, fCol] = 'f';
                }
            }
            if (lost)
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
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

        public static int[] Coordinates(int row, int col, int rows, int cols)
        {
            if (row < 0)
            {
                row = rows - 1;
            }
            else if (row >= rows)
            {
                row = 0;
            }

            if (col < 0)
            {
                col = cols - 1;
            }
            else if (col >= cols)
            {
                col = 0;
            }
            return new int[] { row, col };
        }
    }
}
