using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }
            int position = 0;

            while (true)
            {
                int stepsCounter = 1;
                int fuel = 0;
                Queue<string> pumpsLeft = new Queue<string>(pumps);
                for (int i = 1; i < n; i++)
                {
                    int[] currPump = pumpsLeft.Dequeue()
                                              .Split()
                                              .Select(int.Parse)
                                              .ToArray();
                    fuel += currPump[0] - currPump[1];
                    if (fuel < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        position++;
                        break;
                    }
                    else
                    {
                        stepsCounter++;
                    }
                }
                if (stepsCounter == n)
                {
                    Console.WriteLine(position);
                    break;
                }
            }
        }
    }
}
