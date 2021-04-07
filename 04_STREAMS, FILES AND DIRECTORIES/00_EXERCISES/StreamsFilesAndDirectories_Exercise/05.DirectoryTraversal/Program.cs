using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData = new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                if (!filesData[extension].ContainsKey(fileName))
                {
                    filesData[extension].Add(fileName, kbSize);
                }
            }
            Dictionary<string, Dictionary<string, double>> sortedData = filesData.OrderByDescending(kvp => kvp.Value.Count)
                                                                              .ThenBy(kvp => kvp.Key)
                                                                              .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> result = new List<string>();

            foreach (var kvp in sortedData)
            {
                result.Add(kvp.Key);
                foreach (var data in kvp.Value.OrderBy(kvp2 => kvp2.Value))
                {
                    result.Add($"--{data.Key} - {data.Value}kb");
                }
            }

            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            File.WriteAllLines(filePath, result);
        }
    }
}
