using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothesInput = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardobe.ContainsKey(color))
                {
                    wardobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < clothesInput.Length; j++)
                {
                    if (!wardobe[color].ContainsKey(clothesInput[j]))
                    {
                        wardobe[color].Add(clothesInput[j],0);
                    }
                    wardobe[color][clothesInput[j]]++;
                }
            }
            string[] searchFor = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string colorSearch = searchFor[0];
            string clothing = searchFor[1];

            foreach (var kvp in wardobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var kvp2 in kvp.Value)
                {
                    Console.Write($"* {kvp2.Key} - {kvp2.Value}");
                    if (kvp.Key == colorSearch && kvp2.Key == clothing)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
