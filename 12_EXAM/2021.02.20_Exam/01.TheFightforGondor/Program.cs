using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightforGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());
            List<Stack<int>> orcWaves = new List<Stack<int>>();

            for (int i = 1; i <= wavesCount; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine()
                                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(int.Parse)
                                                        .ToArray());
                orcWaves.Add(orcs);

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }                               
            }

            Stack<int> currWave = new Stack<int>(orcWaves[0]);
            while (plates.Count > 0 && orcWaves.Count > 0)
            {
                if (currWave.Count == 0)
                {
                    orcWaves.RemoveAt(0);
                    if (orcWaves.Count == 0)
                    {
                        break;
                    }
                    currWave = orcWaves[0];
                }

                int plate = plates.Peek();

                while (plate != 0)
                {
                    if (currWave.Count == 0)
                    {
                        orcWaves.RemoveAt(0);
                        if (orcWaves.Count == 0)
                        {
                            break;
                        }
                        currWave = orcWaves[0];
                    }

                    int orc = currWave.Peek();
                    if (orc > plate)
                    {
                        plates.Dequeue();
                        int orcValue = orc - plate;
                        currWave.Pop();
                        currWave.Push(orcValue);
                        plate = 0;
                    }
                    else if (plate > orc)
                    {
                        currWave.Pop();
                        plate -= orc;
                    }
                    else
                    {
                        currWave.Pop();
                        plates.Dequeue();
                        plate = 0;
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcWaves[0])}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
