using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../../text.txt";
            string pattern = @"[-,.!?]";
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter("../../../firstResult.txt"))
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (lineNumber++ % 2 == 0)
                        {
                            string finalWords = Regex.Replace(line,pattern,"@");

                            string[] finalLine = finalWords.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            writer.WriteLine(string.Join(' ', finalLine.Reverse()));
                            Console.WriteLine(string.Join(' ', finalLine.Reverse()));
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
