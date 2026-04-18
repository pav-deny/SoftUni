using System.Text;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split(@"\", StringSplitOptions.RemoveEmptyEntries);

            string[] file = filePath[filePath.Length - 1].Split(".", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            string fileName = file[0];
            string fileExtension = file[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
