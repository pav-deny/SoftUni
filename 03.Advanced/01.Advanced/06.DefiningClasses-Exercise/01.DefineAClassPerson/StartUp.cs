namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new()
            {
                Name = "Bob",
                Age = 40
            };

            Person person2 = new("Dave", 20);
        }
    }
}
