using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.CitiesbyContinentandCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> ccc = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!ccc.ContainsKey(continent))
                {
                    ccc.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!ccc[continent].ContainsKey(country))
                {
                    ccc[continent].Add(country, new List<string>());
                }
                ccc[continent][country].Add(city);
            }

            foreach (var kvp in ccc)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var kvp2 in kvp.Value)
                {
                    Console.Write($"    {kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
