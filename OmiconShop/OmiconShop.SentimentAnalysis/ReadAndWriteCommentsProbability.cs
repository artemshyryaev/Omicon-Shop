using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OmiconShop.SentimentAnalysis
{
    public class ReadAndWriteCommentsProbability
    {
        readonly string path;

        public ReadAndWriteCommentsProbability(int productId)
        {
            path = CombinePath("App_Data\\SentimentData\\", productId);
        }

        string CombinePath(string folderName, int productId)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName, $"yelp_probability_{productId}.txt");

        void DirectoryCreation(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void WriteProbabilityData(float probability)
        {
            DirectoryCreation(path);

            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(Convert.ToString(probability));
            }
        }

        public int GetAverageProbabilityMark()
        {
            float mark = 0;
            using (var reader = new StreamReader(path))
            {
                int linesCount = 0;
                foreach (var line in reader.ReadLine())
                {
                    linesCount++;
                    mark += line;
                }
                mark = mark / linesCount;
            };

            return (int)mark;
        }
    }
}
