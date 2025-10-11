namespace DirectoryTraversal
{
    using System;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directory = new(inputFolderPath);

            Dictionary<string, List<FileInfo>> filesByExtension = new();

            foreach (FileInfo file in directory.GetFiles())
            {
                if (!filesByExtension.ContainsKey(file.Extension))
                    filesByExtension[file.Extension] = new List<FileInfo>();
                   
                filesByExtension[file.Extension].Add(file);
            }

            StringBuilder sb = new();
            foreach ((string extension, List<FileInfo> files) in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(extension);

                foreach (FileInfo file in files)
                    sb.AppendLine($"--{file.Name} - {file.Length / 1024d}kb");
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);

            File.WriteAllText(Path.Combine(desktopPath, reportFileName), textContent);
        }
    }
}

