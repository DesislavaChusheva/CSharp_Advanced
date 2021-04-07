using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Reverse()
                                        .Select(int.Parse)
                                        .ToList();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> notDivided = n => n % divider != 0;
            List<int> finalList = numbers.Where(n => notDivided(n)).ToList();
            Console.WriteLine(string.Join(' ', finalList));
        }
    }
}
