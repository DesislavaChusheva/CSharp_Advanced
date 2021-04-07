using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currRow = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }


            string[] coordinatesDuals = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();
            int aliveCells = 0;
            int sum = 0;

            for (int i = 0; i < coordinatesDuals.Length; i++)
            {
                string dual = coordinatesDuals[i].ToString();
                int[] arg = dual.Split(',')
                                .Select(int.Parse)
                                .ToArray();
                int coordinateRow = arg[0];
                int coordinateCol = arg[1];
                int bomb = matrix[coordinateRow, coordinateCol];
                if (bomb < 0)
                {
                    continue;
                }
                matrix[coordinateRow, coordinateCol] = 0;

                int[] left = new int[2] { coordinateRow, coordinateCol + 1 };
                int[] right = new int[2] { coordinateRow, coordinateCol - 1 };
                int[] up = new int[2] { coordinateRow - 1, coordinateCol };
                int[] down = new int[2] { coordinateRow + 1, coordinateCol };
                int[] diagUpRight = new int[2] { coordinateRow - 1, coordinateCol + 1 };
                int[] diafUpLeft = new int[2] { coordinateRow - 1, coordinateCol - 1 };
                int[] diagDownRight = new int[2] { coordinateRow + 1, coordinateCol + 1 };
                int[] diagDownLeft = new int[2] { coordinateRow + 1, coordinateCol - 1 };

                List<int[]> allCoordinates = new List<int[]>
                { left, right, up, down, diagUpRight, diafUpLeft, diagDownRight, diagDownLeft };

                for (int j = 0; j < allCoordinates.Count; j++)
                {
                    int currRow = allCoordinates[j][0];
                    int currCol = allCoordinates[j][1];
                    if (IsPositionValid(currRow, currCol, n, n) && matrix[currRow, currCol] > 0)
                    {
                        matrix[currRow, currCol] -= bomb;
                    }
                }
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < n; row++)
            {
                List<int> currRow = new List<int>();
                for (int col = 0; col < n; col++)
                {
                    currRow.Add(matrix[row, col]);
                }
                Console.WriteLine(string.Join(" ", currRow));
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
