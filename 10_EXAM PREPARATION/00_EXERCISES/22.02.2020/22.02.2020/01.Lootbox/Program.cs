using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLine = new Queue<int>(Console.ReadLine()
                                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse));
            Stack<int> secondLine = new Stack<int>(Console.ReadLine()
                                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse));
            List<int> claimedItems = new List<int>();

            while (firstLine.Count > 0 && secondLine.Count > 0)
            {
                int firstInt = firstLine.Peek();
                int secondInt = secondLine.Pop();

                int sum = firstInt + secondInt;

                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstLine.Dequeue();
                }
                else
                {
                    firstLine.Enqueue(secondInt);
                }
            }

            if (firstLine.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int finSum = claimedItems.Sum();
            if (finSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {finSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {finSum}");
            }
        }
    }
}
