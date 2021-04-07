using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int> (Console.ReadLine()
                                      .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray());
            int taskForKilling = int.Parse(Console.ReadLine());
            int killer = 0;

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskForKilling)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskForKilling}");
                    killer = thread;
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                }
                threads.Dequeue();
            }
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
