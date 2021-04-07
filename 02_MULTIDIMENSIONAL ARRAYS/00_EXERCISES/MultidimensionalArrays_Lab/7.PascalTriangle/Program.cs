using System;
using System.Linq;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            pascal[0] = new long[] { 1 };

            for (int row = 1; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    long right = 0;
                    long left = 0;

                    if (col != row)
                    {
                        right = pascal[row - 1][col];
                    }
                    if (col - 1 >= 0)
                    {
                        left = pascal[row - 1][col - 1];
                    }
                    pascal[row][col] = left + right;
                }
            }
            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
