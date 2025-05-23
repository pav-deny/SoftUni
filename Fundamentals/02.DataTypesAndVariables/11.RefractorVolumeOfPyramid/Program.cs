namespace _11.RefractorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            Console.Write($"Length: ");
            Console.Write($"Width: ");
            Console.Write($"Height: ");

            double volume = ((length * width) * heigth) / 3;

            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
