using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine()
                                                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine()
                                                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse));

            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            bool pouchFilled = false;

            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int effect = bombEffects.Peek();
                int casing = bombCasings.Peek();

                int sum = effect + casing;
                bool bombFound = false;

                switch (sum)
                {
                    case 40:
                        bombs["Datura Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        bombFound = true;
                        break;
                    case 60:
                        bombs["Cherry Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        bombFound = true;
                        break;
                    case 120:
                        bombs["Smoke Decoy Bombs"]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        bombFound = true;
                        break;

                    default:
                        break;
                }
                if (!bombFound)
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }
                if (bombs.All(b => b.Value >= 3))
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    pouchFilled = true;
                    break;
                }
            }
            if (!pouchFilled)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            foreach (var kvp in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
