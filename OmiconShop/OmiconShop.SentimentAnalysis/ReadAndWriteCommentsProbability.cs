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
            path = CombinePath("Data", productId);
        }

        string CombinePath(string folderName, int productId) 
            => Path.Combine(Environment.CurrentDirectory, folderName, $"yelp_probability_{productId}.txt");

        public void WriteProbabilityData(float probability)
        {
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
