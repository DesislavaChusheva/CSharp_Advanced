using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../../text.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (StreamWriter writer = new StreamWriter("../../../secondResult"))
                {
                    string line = reader.ReadLine();
                    int lineCounter = 1;
                    while (line != null)
                    {
                        int lettersCounter = 0;
                        int signsCounter = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsLetter(line[i]))
                            {
                                lettersCounter++;
                            }
                            else if (char.IsPunctuation(line[i]))
                            {
                                signsCounter++;
                            }
                        }

                        writer.WriteLine($"Line {lineCounter}: {line} ({lettersCounter})({signsCounter})");
                        Console.WriteLine($"Line {lineCounter}: {line} ({lettersCounter})({signsCounter})");

                        lineCounter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
