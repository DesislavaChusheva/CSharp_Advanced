using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<char> openings = new Stack<char>();
            bool flag = true;
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{')
                {
                    openings.Push(expression[i]);
                }
                else
                {
                    if (expression[i] == ')')
                    {
                        if (openings.Any() && openings.Pop() == '(')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                    else if(expression[i] == ']')
                    {
                        if (openings.Any() && openings.Pop() == '[')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                    else if (expression[i] == '}')
                    {
                        if (openings.Any() && openings.Pop() == '{')
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
