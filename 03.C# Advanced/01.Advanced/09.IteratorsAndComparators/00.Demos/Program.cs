namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new() { Name = "Lucky", Age = 9 };
            Cat cat2 = new() { Name = "Tom", Age = 13 };

            CatsCollection cats = new() { cat1, cat2 };

            foreach (Cat cat in cats) 
                Console.WriteLine(cat.Name);

            Params(2, 3, 4, 5, 5, 6 ,7 , 8, 8, 8);

            SortedSet<Cat> sc = new();
            sc.Add(cat1);
            sc.Add(cat2);

            foreach (Cat cat in cats)
                Console.WriteLine(cat.Name);
        }

        static void Params(params int[] yo)
        {

        }
    }
}
