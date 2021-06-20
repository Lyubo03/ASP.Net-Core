namespace Regression_ExercisesML.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.ML;
    using Microsoft.ML.Data;
    using Regression_ExercisesML.Model;
    using Microsoft.ML.Trainers.FastTree;

    public static class ModelBuilder
    {
        private static string TRAIN_DATA_FILEPATH = @"C:\Users\lubos\Desktop\carsbg.csv";
        private static string MODEL_FILEPATH = @"C:\Users\lubos\AppData\Local\Temp\MLVSTools\Regression.ExercisesML\Regression.ExercisesML.Model\MLModel.zip";
        // Create MLContext to be shared across the model creation workflow objects 
        // Set a random seed for repeatable/deterministic results across multiple trainings.
        private static MLContext mlContext = new MLContext(seed: 1);

        public static void CreateModel()
        {
            // Load Data
            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: TRAIN_DATA_FILEPATH,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Build training pipeline
            IEstimator<ITransformer> trainingPipeline = BuildTrainingPipeline(mlContext);

            // Train Model
            ITransformer mlModel = TrainModel(mlContext, trainingDataView, trainingPipeline);

            // Evaluate quality of Model
            Console.WriteLine("=============== Cross-validating to get model's accuracy metrics ===============");
            var crossValidationResults = mlContext.Regression.CrossValidate(trainingDataView, trainingPipeline, numberOfFolds: 5, labelColumnName: "Price");

            // Save model
            SaveModel(mlContext, mlModel, MODEL_FILEPATH, trainingDataView.Schema);
        }

        public static IEstimator<ITransformer> BuildTrainingPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations 
            var dataProcessPipeline = mlContext.Transforms.Categorical.OneHotEncoding(new[] { new InputOutputColumnPair("Make", "Make"), new InputOutputColumnPair("FuelType", "FuelType"), new InputOutputColumnPair("Year", "Year"), new InputOutputColumnPair("Gear", "Gear") })
                                      .Append(mlContext.Transforms.Categorical.OneHotHashEncoding(new[] { new InputOutputColumnPair("Model", "Model") }))
                                      .Append(mlContext.Transforms.Concatenate("Features", new[] { "Make", "FuelType", "Year", "Gear", "Model", "HorsePower", "Range", "CubicCapacity" }));
            // Set the training algorithm 
            var trainer = mlContext.Regression.Trainers.FastTreeTweedie(new FastTreeTweedieTrainer.Options() { NumberOfLeaves = 109, MinimumExampleCountPerLeaf = 10, NumberOfTrees = 100, LearningRate = 0.1353359f, Shrinkage = 3.833874f, LabelColumnName = "Price", FeatureColumnName = "Features" });

            var trainingPipeline = dataProcessPipeline.Append(trainer);

            return trainingPipeline;
        }

        public static ITransformer TrainModel(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            Console.WriteLine("=============== Training  model ===============");

            ITransformer model = trainingPipeline.Fit(trainingDataView);

            Console.WriteLine("=============== End of training process ===============");
            return model;
        }

        private static void Evaluate(MLContext mlContext, IDataView trainingDataView, IEstimator<ITransformer> trainingPipeline)
        {
            // Cross-Validate with single dataset (since we don't have two datasets, one for training and for evaluate)
            // in order to evaluate and get the model's accuracy metrics
           
        }

        private static void SaveModel(MLContext mlContext, ITransformer mlModel, string modelRelativePath, DataViewSchema modelInputSchema)
        {
            // Save/persist the trained model to a .ZIP file
            Console.WriteLine($"=============== Saving the model  ===============");
            mlContext.Model.Save(mlModel, modelInputSchema, GetAbsolutePath(modelRelativePath));
            Console.WriteLine("The model is saved to {0}", GetAbsolutePath(modelRelativePath));
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}