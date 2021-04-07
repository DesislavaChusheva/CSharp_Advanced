using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../../words.txt");
            string actualResult = Path.Combine("../../../actualResults.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordsCount.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("../../../../text.txt");
            string[] wordsFromText = text.Split(new char[] { ' ', ',', '.', '!', '?','-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < wordsFromText.Length; i++)
            {
                if (wordsCount.ContainsKey(wordsFromText[i].ToLower()))
                {
                    wordsCount[wordsFromText[i].ToLower()]++;
                }
            }

            Dictionary<string, int> sortedCounts = wordsCount.OrderByDescending(x => x.Value)
                                                             .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            List<string> finalLines = sortedCounts.Select(kvp => $"{kvp.Key} - {kvp.Value}")
                                                  .ToList();

            File.WriteAllLines(actualResult, finalLines);
            Console.WriteLine(string.Join(Environment.NewLine, finalLines));
        }
    }
}
