using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            string item = Console.ReadLine();
            int counter = 0;

            foreach (var box in boxes)
            {
                if (box.CompareTo(item) == 1)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
