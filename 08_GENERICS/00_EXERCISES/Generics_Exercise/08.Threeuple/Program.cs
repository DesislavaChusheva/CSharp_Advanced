using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string fullName = firstLine[0] + " " + firstLine[1];
            List<string> town = firstLine.Skip(3).ToList();
            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>
                (fullName, firstLine[2], string.Join(" ", town));

            string[] secondLine = Console.ReadLine().Split();
            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>
                (secondLine[0], int.Parse(secondLine[1]), secondLine[2] == "drunk");

            string[] thirdLine = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>
                (thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

            Console.WriteLine(firstThreeuple.ToString());
            Console.WriteLine(secondThreeuple.ToString());
            Console.WriteLine(thirdThreeuple.ToString());
        }
    }
}
