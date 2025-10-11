namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] binaryBuffer = File.ReadAllBytes(binaryFilePath);

            byte[] bytes = File.ReadAllLines(bytesFilePath).Select(byte.Parse).ToArray();

            List<byte> matchingBytes = new();

            foreach (byte b in binaryBuffer)
            {
                if (bytes.Contains(b))
                    matchingBytes.Add(b);
            }

            File.WriteAllBytes(outputPath, matchingBytes.ToArray());
        }
    }
}
