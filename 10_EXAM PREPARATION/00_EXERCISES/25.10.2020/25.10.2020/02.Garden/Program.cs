using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            int N = dimensions[0];
            int M = dimensions[1];

            int[,] garden = new int[N, M];
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string command = Console.ReadLine();
            List<int[]> flowers = new List<int[]>();

            while (command != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();
                int fRow = coordinates[0];
                int fCol = coordinates[1];
                if (IsPositionValid(fRow, fCol, N, M))
                {
                    garden[fRow, fCol] = -1;
                    flowers.Add(new int[] { fRow, fCol });
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                command = Console.ReadLine();
            }

            foreach (var flower in flowers)
            {
                int row = flower[0];
                int col = flower[1];
                for (int r = 0; r < N; r++)
                {
                    garden[r, col]++;
                }
                for (int c = 0; c < M; c++)
                {
                    garden[row, c]++;
                }
            }
            for (int row = 0; row < N; row++)
            {
                List<int> currRow = new List<int>();
                for (int col = 0; col < M; col++)
                {
                    currRow.Add(garden[row,col]);
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
