namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new();
            Cat cat = new();
            Animal animal = new();

            animal.Eat();

            dog.Eat();
            dog.Bark();

            cat.Eat();
            cat.Meow();
        }
    }
}
