using System;
using System.Linq;

namespace _02.KnightsofHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(n => $"Sir {n}")
                                    .ToArray();
            Action<string[]> printer = n => Console.WriteLine(string.Join(Environment.NewLine, n));
            printer(names);
        }
    }
}
