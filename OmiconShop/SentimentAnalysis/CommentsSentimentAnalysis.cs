using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;

namespace SentimentAnalysis
{
    public class CommentsSentimentAnalysis
    {
        readonly MLContext mlContext;
        string Sentiment { get; set; }
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");


        public CommentsSentimentAnalysis(string sentiment)
        {
            this.mlContext = new MLContext();
            this.Sentiment = sentiment;
        }

        int GetAverageProbability()
        {
            var model = BuildAndTrainModel(mlContext);
            var statementProbability = PredictStatementProbability(mlContext, model, Sentiment);
            var probability = new ReadAndWriteCommentsProbability(statementProbability);
            probability.WriteProbabilityData();

            return probability.GetAverageProbabilityMark();
        }

        private static ITransformer BuildAndTrainModel(MLContext mlContext)
        {
            var splitDataView = LoadData(mlContext);

            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            return estimator.Fit(splitDataView.TrainSet);
        }

        private static TrainTestData LoadData(MLContext mlContext)
        {
            var dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);

            return mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
        }

        private static float PredictStatementProbability(MLContext mlContext, ITransformer model, string statement)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentProbability>(model);

            var sampleStatement = new SentimentData
            {
                SentimentText = statement
            };

            return predictionFunction.Predict(sampleStatement).Probability;
        }
    }
}
