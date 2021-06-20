namespace Regression_ExercisesML.ConsoleApp
{
    using System;
    using Regression_ExercisesML.Model;
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            var sampleData = new ModelInput()
            {
                Make = "VW",
                Model = "Golf",
                FuelType = "Бензин",
                Year = "01/01/1992",
                HorsePower = 55,
                Range = 270000,
                Gear = "Ръчни",
                CubicCapacity = 1400,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Price with predicted Price from sample data...\n\n");
            Console.WriteLine($"Make: {sampleData.Make}");
            Console.WriteLine($"Model: {sampleData.Model}");
            Console.WriteLine($"FuelType: {sampleData.FuelType}");
            Console.WriteLine($"Year: {sampleData.Year}");
            Console.WriteLine($"HorsePower: {sampleData.HorsePower}");
            Console.WriteLine($"Range: {sampleData.Range}");
            Console.WriteLine($"Gear: {sampleData.Gear}");
            Console.WriteLine($"CubicCapacity: {sampleData.CubicCapacity}");
            Console.WriteLine($"\n\nPredicted Price: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}