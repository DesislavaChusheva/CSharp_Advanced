using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
            Func<int[], int> cutsomMin = n =>
            {
                int minNum = int.MaxValue;
                foreach (int number in numbers)
                {
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                }
                return minNum;
            };
            Console.WriteLine(cutsomMin(numbers));
        }
    }
}
