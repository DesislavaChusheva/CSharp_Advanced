using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        stack.Push(text);
                        text = text + command[1];
                        break;
                    case "2":
                        stack.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(command[1]));
                        break;
                    case "3":
                        Console.WriteLine(text.ElementAt(int.Parse(command[1]) - 1));
                        break;
                    case "4":
                        text = stack.Pop();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
