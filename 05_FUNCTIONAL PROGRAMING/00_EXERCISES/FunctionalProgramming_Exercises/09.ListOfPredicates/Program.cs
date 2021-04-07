using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            List<int> numbers = Enumerable.Range(1, rangeEnd).ToList();
            Func<int, int, bool> predicate = (num, d) => num % d == 0;
            foreach (int num in numbers)
            {
                if (dividers.All(d => predicate(num, d)))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
