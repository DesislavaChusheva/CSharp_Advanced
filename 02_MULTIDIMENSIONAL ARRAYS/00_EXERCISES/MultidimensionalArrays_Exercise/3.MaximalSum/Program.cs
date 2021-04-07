using System;
using System.Linq;

namespace _3.MaximalSum
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
            int n = 3;

            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] cols = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            int biggestSum = int.MinValue;
            int rowBiggest = 0;
            int colBiggest = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    bool flag = true;
                    for (int i = row; i < row + n; i++)
                    {
                        for (int j = col; j < col + n; j++)
                        {
                            if (i >= rowsCount || j >= colsCount)
                            {
                                flag = false;
                            }
                        }
                    }
                    if (flag)
                    {
                        int sum = 0;
                        for (int i = row; i < row + n; i++)
                        {
                            for (int j = col; j < col + n; j++)
                            {
                                sum += matrix[i, j];
                            }
                        }
                        if (sum > biggestSum)
                        {
                            biggestSum = sum;
                            rowBiggest = row;
                            colBiggest = col;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {biggestSum}");
            for (int row = rowBiggest; row < rowBiggest + n; row++)
            {
                for (int col = colBiggest; col < colBiggest + n; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
