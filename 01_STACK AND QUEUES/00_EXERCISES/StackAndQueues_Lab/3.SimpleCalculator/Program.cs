using System;
using System.Collections.Generic;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(expression);
            Stack<string> exElemens = new Stack<string>();

            foreach (var item in expression)
            {
                exElemens.Push(item);
            }

            while (exElemens.Count > 1)
            {
                int firstNumber = int.Parse(exElemens.Pop());
                string sign = exElemens.Pop();
                int secondNumber = int.Parse(exElemens.Pop());
                int result = 0;

                switch (sign)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    default:
                        break;
                }

                exElemens.Push(result.ToString());
            }
            Console.WriteLine(exElemens.Pop());
        }
    }
}
