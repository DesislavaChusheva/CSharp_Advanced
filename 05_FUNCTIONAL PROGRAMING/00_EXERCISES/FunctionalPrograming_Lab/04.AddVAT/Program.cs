using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine()
                                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(double.Parse)
                                         .Select(p => p + p * 0.20)
                                         .ToList();
            foreach (double price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
