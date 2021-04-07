using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> reservations = new HashSet<string>();

            while (input != "PARTY")
            {
                reservations.Add(input);
                input = Console.ReadLine();
            }
            while (input != "END")
            {
                reservations.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(reservations.Count);
            foreach (var item in reservations.OrderByDescending(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(item);
            }
        }
    }
}
