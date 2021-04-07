using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());
            bool flag = true;

            while (orders.Any())
            {
                if (quantity >= orders.Peek())
                {
                    quantity -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
