using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsofElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
         
            int n = lenghts[0];
            int m = lenghts[1];
            HashSet<int> nNumbers = new HashSet<int>();
            HashSet<int> mNumbers = new HashSet<int>();
            HashSet<int> comman = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                nNumbers.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                mNumbers.Add(int.Parse(Console.ReadLine()));
            }
            foreach (var nItem in nNumbers)
            {
                foreach (var mItem in mNumbers)
                {
                    if (nItem == mItem)
                    {
                        comman.Add(nItem);
                    }
                }
            }
            Console.WriteLine(string.Join(' ',comman));
        }
    }
}
