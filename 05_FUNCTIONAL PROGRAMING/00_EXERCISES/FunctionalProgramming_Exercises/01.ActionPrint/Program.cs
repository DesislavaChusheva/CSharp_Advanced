using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printer = input => Console.WriteLine(string.Join(Environment.NewLine, input));
            printer(input);
        }
    }
}
