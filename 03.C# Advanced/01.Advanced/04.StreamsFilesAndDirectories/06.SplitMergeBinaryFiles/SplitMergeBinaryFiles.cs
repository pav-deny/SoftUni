namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }
        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] sourceFile = File.ReadAllBytes(sourceFilePath);

            int partOneLength = (sourceFile.Length + 1) / 2;

            using FileStream fs = new(sourceFilePath, FileMode.Open);

            byte[] partOneBuffer = new byte[partOneLength];
            fs.Read(partOneBuffer, 0, partOneLength);

            File.WriteAllBytes(partOneFilePath, partOneBuffer);

            int partTwoLength = sourceFile.Length - partOneLength;

            byte[] partTwoBuffer = new byte[partTwoLength];
            fs.Read(partTwoBuffer, 0, partTwoLength);

            File.WriteAllBytes(partTwoFilePath, partTwoBuffer);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] partOne = File.ReadAllBytes(partOneFilePath);
            byte[] partTwo = File.ReadAllBytes(partTwoFilePath);

            using (FileStream fs = new(joinedFilePath, FileMode.Create))
                fs.Write(partOne, 0, partOne.Length);

            using (FileStream fs = new(joinedFilePath, FileMode.Append))
                fs.Write(partTwo, 0, partTwo.Length);
        }

    }
}
