using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.CiuntSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine()
                                    .Split()
                                    .Select(double.Parse)
                                    .ToArray();
            Dictionary<double, int> counts = new Dictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!counts.ContainsKey(array[i]))
                {
                    counts.Add(array[i],0);
                }
                counts[array[i]]++;
            }
            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
