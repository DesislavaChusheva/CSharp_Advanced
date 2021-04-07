using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            Queue<int> numbers = new Queue<int>(input);
            Queue<int> evens = new Queue<int>();
            while (numbers.Any())
            {
                int currNumber = numbers.Dequeue();
                if (currNumber % 2 == 0)
                {
                    evens.Enqueue(currNumber);
                }
            }
            Console.WriteLine(string.Join(", ", evens));
        }
    }
}
