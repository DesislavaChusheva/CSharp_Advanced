using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> filteredNames = (name, lenght) => name.Length <= lenght;
            List<string> finalNames = names.Where(n => filteredNames(n, lenght)).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, finalNames));
        }
    }
}
