using System;
using System.Collections.Generic;
using System.IO;

namespace DemXe
{
    internal class Program
    {
        // đọc dữ liệu từ file và trả về mảng các dòng
        private static string[] ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
        // đếm số lần xuất hiện của biển số trong mảng và trả về một từ điển
        private static Dictionary<string, int> CountOccurrences(string[] lines)
        {
            var occurrences = new Dictionary<string, int>(StringComparer.Ordinal);

            foreach (var line in lines)
            {
                if (occurrences.ContainsKey(line))
                {
                    occurrences[line]++;
                }
                else
                {
                    occurrences[line] = 1;
                }
            }

            return occurrences;
        }
        // ghi số lần xuất hiện của biển số vào file
        private static void WriteOccurrencesToFile(Dictionary<string, int> occurrences, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var pair in occurrences)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }

        static void Main(string[] args)
        {
            const string filename = "In.txt";
            var lines = ReadFile(filename);
            var occurrences = CountOccurrences(lines);
            WriteOccurrencesToFile(occurrences, "Out.txt");
        }
    }
}
