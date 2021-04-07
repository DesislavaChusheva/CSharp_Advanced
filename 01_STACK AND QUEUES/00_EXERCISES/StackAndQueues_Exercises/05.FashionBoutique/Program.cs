using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int rack = rackCapacity;
            int countRacks = 1;

            while (clothes.Any())
            {
                if (rack >= clothes.Peek())
                {
                    rack -= clothes.Pop();
                }
                else
                {
                    rack = rackCapacity - clothes.Pop();
                    countRacks++;
                }
            }
            Console.WriteLine(countRacks);
        }
    }
}
