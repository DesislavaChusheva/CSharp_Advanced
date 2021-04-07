using System;
using System.Linq;

namespace _4.MatrixShuffling
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

            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string[] cols = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "swap" && command.Length == 5)
                {
                    int firstRow = int.Parse(command[1]);
                    int firstCol = int.Parse(command[2]);
                    int secondRow = int.Parse(command[3]);
                    int secondCol = int.Parse(command[4]);
                    if ((firstRow >= 0 && firstRow < rowsCount) 
                        && (firstCol >= 0 && firstCol < colsCount) 
                        && (secondRow >= 0 && secondRow < rowsCount)
                        && (secondCol >= 0 && secondCol < colsCount))
                    {
                        string firstItem = matrix[firstRow, firstCol];
                        string secondItem = matrix[secondRow, secondCol];

                        matrix[firstRow, firstCol] = secondItem;
                        matrix[secondRow, secondCol] = firstItem;
                        for (int row = 0; row < rowsCount; row++)
                        {
                            for (int col = 0; col < colsCount; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
