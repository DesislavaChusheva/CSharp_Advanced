using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charCounter = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!charCounter.ContainsKey(input[i]))
                {
                    charCounter.Add(input[i],0);
                }
                charCounter[input[i]]++;
            }
            foreach (var item in charCounter)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
