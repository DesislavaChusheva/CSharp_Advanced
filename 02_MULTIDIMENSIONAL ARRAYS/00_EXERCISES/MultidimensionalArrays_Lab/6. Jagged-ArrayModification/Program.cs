using System;
using System.Linq;

namespace _6._Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsN = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowsN][];

            for (int row = 0; row < rowsN; row++)
            {
                int[] cols = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                matrix[row] = cols;
            }

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (IsValid(row, matrix.Length) && IsValid(col, matrix[row].Length))
                {
                    if (command[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsValid(int coordinate, int n)
        {
            return coordinate >= 0 && coordinate < n;
        }
    }
}
