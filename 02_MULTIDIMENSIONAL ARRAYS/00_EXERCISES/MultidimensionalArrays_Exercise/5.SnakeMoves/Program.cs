using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int N = size[0];
            int M = size[1];

            char[,] matrix = new char[N, M];

            char[] snake = Console.ReadLine().ToCharArray();
            int index = 0;

            for (int row = 0; row < N; row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = M - 1; col >= 0; col--)
                    {
                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = snake[index];
                        index++;
                    }
                }
                else
                {
                    for (int col = 0; col < M; col++)
                    {

                        if (index == snake.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = snake[index];
                        index++;
                    }
                }
            }
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
