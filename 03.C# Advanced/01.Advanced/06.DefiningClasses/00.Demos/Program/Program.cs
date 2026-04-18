using _00.Demos.Animals;

namespace _00.Demos.Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new(1, "Lucky", Colour.Grey);


            Console.WriteLine(cat.Name);
            Console.WriteLine(cat.Meow());
            Console.WriteLine(Cat.Legs);
        }
    }
}
