using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensorOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            string command = Console.ReadLine();

            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> filter = n => true;
            if (command == "odd")
            {
                filter = n => n % 2 != 0;
            }
            else if (command == "even")
            {
                filter = n => n % 2 == 0;
            }
            List<int> printNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    printNumbers.Add(number);
                }
            }
            Console.WriteLine(string.Join(' ', printNumbers));
        }
    }
}
