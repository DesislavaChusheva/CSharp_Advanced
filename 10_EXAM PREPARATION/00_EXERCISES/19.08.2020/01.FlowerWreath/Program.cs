using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreath
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                                                      .Split(", ")
                                                      .Select(int.Parse)
                                                      .ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                                                      .Split(", ")
                                                      .Select(int.Parse)
                                                      .ToArray());
            int flowersLeft = 0;
            int wreaths = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Pop() + roses.Dequeue();

                if (sum == 15)
                {
                    wreaths++;
                }
                else if (sum < 15)
                {
                    flowersLeft += sum;
                }
                else
                {
                    if (sum % 2 == 0)
                    {
                        flowersLeft += 14;
                    }
                    else
                    {
                        wreaths++;
                    }
                }
            }

            wreaths += flowersLeft / 15;

            if (wreaths < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
        }
    }
}
