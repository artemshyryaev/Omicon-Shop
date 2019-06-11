using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.SentimentAnalysis
{
    public class ReadAndWriteCommentsProbability
    {
        readonly string path;
        readonly string fullPath;
        int ProductId { get; set; }

        public ReadAndWriteCommentsProbability(int productId)
        {
            this.ProductId = productId;
            path = CombinePath("App_Data\\SentimentData\\");
            fullPath = CombinePath("App_Data\\SentimentData\\", productId);
        }

        string CombinePath(string folderName)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

        string CombinePath(string folderName, int productId)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName, $"yelp_probability_{ ProductId }.txt");

        void DirectoryCreation(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public async Task WriteProbabilityData(float probability)
        {
            DirectoryCreation(path);

            using (var writer = new StreamWriter(fullPath, true))
            {
                await writer.WriteLineAsync(Convert.ToString(probability));
                writer.Flush();
                writer.Close();
            }
        }

        public int GetAverageProbabilityMark()
        {
            if (!System.IO.File.Exists(fullPath))
                return 0;

            float mark = 0;
            int linesCount = 0;
            var lines = File.ReadAllLines(fullPath);

            foreach (var line in lines)
            {
                linesCount++;
                string newLine = line;
                mark += float.Parse(newLine);
            }
            mark = mark / linesCount;

            return GetProbabilityMark(mark);
        }

        public int GetProbabilityMark(float mark)
        {
            var newMark = mark.ToString("0.00");
            string[] parts = newMark.Split('.');
            return int.Parse(parts[1]);
        }
    }
}
