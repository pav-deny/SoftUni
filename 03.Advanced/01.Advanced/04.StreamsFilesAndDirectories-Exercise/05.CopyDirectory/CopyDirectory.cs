namespace CopyDirectory
{
    using System;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath)) 
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);

            DirectoryInfo directory = new(inputPath);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.CopyTo(Path.Combine(outputPath, file.Name));
            }
        }
    }
}
