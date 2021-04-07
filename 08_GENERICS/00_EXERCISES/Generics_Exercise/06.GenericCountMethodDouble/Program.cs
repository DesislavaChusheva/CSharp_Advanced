using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double item = double.Parse(Console.ReadLine());
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
