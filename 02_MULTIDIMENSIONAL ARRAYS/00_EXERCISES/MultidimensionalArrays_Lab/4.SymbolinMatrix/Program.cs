using System;

namespace _4.SymbolinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] cols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool notContained = true;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        notContained = false;
                        Console.WriteLine($"({row}, {col})");
                        break;
                    }
                }
                if (!notContained)
                {
                    break;
                }
            }
            if (notContained)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
