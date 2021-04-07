using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceBetweenDatesInDays(dateOne, dateTwo));
        }
    }
}
