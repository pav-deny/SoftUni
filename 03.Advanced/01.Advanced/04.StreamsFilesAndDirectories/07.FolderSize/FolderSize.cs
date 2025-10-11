using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputPath)
        {
            long size = GetAllFoldersSize(folderPath);

            double sizeInKB = size / 1024.0;
            File.WriteAllText(outputPath, $"{sizeInKB} KB");
        }

        public static long GetAllFoldersSize(string folderPath)
        {
            long size = 0;

            DirectoryInfo directoryInfo = new(folderPath);

            FileInfo[] filesInDir = directoryInfo.GetFiles();

            foreach (FileInfo file in filesInDir)
            {
                size += file.Length;
            }

            DirectoryInfo[] dirsInDir = directoryInfo.GetDirectories();

            foreach (DirectoryInfo dir in dirsInDir)
            {
                size += GetAllFoldersSize(dir.FullName);
            }

            return size;
        }
    }
}
