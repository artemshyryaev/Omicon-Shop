using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SentimentAnalysis
{
    public class ReadAndWriteCommentsProbability
    {
        float Probability { get; set; }
        readonly string path = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_probability.txt");

        public ReadAndWriteCommentsProbability(float probability)
        {
            this.Probability = probability;
        }

        public void WriteProbabilityData()
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(Convert.ToString(Probability));
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
