using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> result = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                result.Push(input[i]);
            }
            while (result.Any())
            {
                Console.Write(result.Pop());
            }
        }
    }
}
