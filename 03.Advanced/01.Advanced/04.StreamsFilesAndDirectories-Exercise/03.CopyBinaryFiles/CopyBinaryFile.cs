namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream inputFs = new(inputFilePath, FileMode.Open, FileAccess.Read);  
            using FileStream outputFs = new(outputFilePath, FileMode.Create, FileAccess.Write);

            //inputFs.CopyTo(outputFs);

            byte[] buffer = new byte[1024];
            int count;

            while ((count = inputFs.Read(buffer, 0, buffer.Length)) != 0)
                outputFs.Write(buffer, 0, count);
        }
    }
}

