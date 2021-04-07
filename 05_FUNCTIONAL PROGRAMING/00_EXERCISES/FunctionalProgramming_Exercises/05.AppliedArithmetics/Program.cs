using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            string command = Console.ReadLine();
            Func<int, int> arithmetics = num => num;
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        arithmetics = num => num + 1;
                        numbers = numbers.Select(arithmetics).ToList();
                        break;
                    case "multiply":
                        arithmetics = num => num * 2;
                        numbers = numbers.Select(arithmetics).ToList();
                        break;
                    case "subtract":
                        arithmetics = num => num - 1;
                        numbers = numbers.Select(arithmetics).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', numbers)); ;
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
