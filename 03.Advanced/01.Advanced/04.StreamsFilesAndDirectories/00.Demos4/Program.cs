namespace _00.Demos4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"Folder\Folder2");
            File.WriteAllText(@"Folder\Me.txt", "Hello");

            string[] files = Directory.GetFiles("Folder");

            FileInfo fileInfo = new(files[0]);

            foreach (string file in files)
                Console.WriteLine(file);

            Console.WriteLine(fileInfo.Length);

            string currentDir = Directory.GetCurrentDirectory();

            string[] dirs = Directory.GetDirectories(currentDir);

            foreach (string dir in dirs)
                Console.WriteLine(dir);
        }
    }
}
