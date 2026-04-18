namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader firstReader = new(firstInputFilePath);
            using StreamReader secondReader = new(secondInputFilePath);

            int a = File.ReadLines(firstInputFilePath).Count();
            int b = File.ReadLines(secondInputFilePath).Count();

            int n = Math.Min(a, b);

            using StreamWriter writer = new(outputFilePath, false);

            for (int i = 0; i < n; i++) 
            {
                writer.WriteLine(firstReader.ReadLine());
                writer.WriteLine(secondReader.ReadLine());
            }

            while (!firstReader.EndOfStream)
            {
                writer.WriteLine(firstReader.ReadLine());
            }

            while (!secondReader.EndOfStream)
            {
                writer.WriteLine(secondReader.ReadLine());
            }
        }
    }
}

