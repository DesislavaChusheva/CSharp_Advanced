using System;
using System.Linq;

namespace _2.SquaresinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int rowsCount = size[0];
            int colsCount = size[1];

            char[,] matrix = new char[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                char[] cols = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(char.Parse)
                                   .ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }
            int count = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (col + 1 < colsCount && row + 1 < rowsCount)
                    {
                        if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
