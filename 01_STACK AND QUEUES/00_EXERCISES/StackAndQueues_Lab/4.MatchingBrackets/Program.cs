using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> openingBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openingBrackets.Push(i);
                }
                if (input[i] == ')')
                {
                    Console.WriteLine(input.Substring(openingBrackets.Peek(), i - openingBrackets.Pop() + 1));
                }
            }
        }
    }
}
