using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string fullName = firstLine[0] + " " + firstLine[1];
            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, firstLine[2]);

            string[] secondLine = Console.ReadLine().Split();
            Tuple<string, int> secondTuple = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));

            string[] thirdLine = Console.ReadLine().Split();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));

            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
