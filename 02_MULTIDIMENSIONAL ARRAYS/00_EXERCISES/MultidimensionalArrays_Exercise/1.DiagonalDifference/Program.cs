using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] cols = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < n; i++)
            {
                firstSum += matrix[i, i];
            }
            int j = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                secondSum += matrix[j, i];
                j++;
            }

            Console.WriteLine(Math.Abs(secondSum - firstSum));
        }
    }
}
