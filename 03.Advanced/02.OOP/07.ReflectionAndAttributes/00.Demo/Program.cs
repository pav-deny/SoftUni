namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Animal> animals = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    Type type = Type.GetType(input);

                    Animal animal = (Animal)Activator.CreateInstance(type);
                    animals.Add(animal);
                }
                catch
                {
                    Console.WriteLine("Invalid Type!");
                }
            }

            Console.Clear();

            foreach (Animal animal in animals)
            {
                Type type = animal.GetType();
                Console.WriteLine(type.Name);
            }
        }
    }
}
