using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();
            int N = nsx[0];
            int S = nsx[1];
            int X = nsx[2];

            int[] input = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();
            Queue<int> numbers = new Queue<int>(input);

            for (int i = 0; i < S; i++)
            {
                if (numbers.Any())
                {
                    numbers.Dequeue();
                }
            }
            if (!numbers.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numbers.Contains(X))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}
