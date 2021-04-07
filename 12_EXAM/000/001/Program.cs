using System;
using System.Collections.Generic;
using System.Linq;

namespace _001
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Stack<int> orcsLeft = new Stack<int>();
            int plate = 0;

            for (int i = 1; i <= wavesCount; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                Stack<int> currWave = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                if (plate == 0)
                {
                    plate = plates.Peek();
                }

                while (currWave.Count != 0)
                {
                    if (plates.Count == 0)
                    {
                        break;
                    }
                    if (plate == 0)
                    {
                        plate = plates.Peek();
                    }

                    int orc = currWave.Peek();

                    if (orc > plate)
                    {
                        orc -= plate;
                        currWave.Pop();
                        currWave.Push(orc);
                        plates.Dequeue();
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
                orcsLeft = currWave;
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsLeft)}");
            }
        }
    }
}
