namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int trips = (int)Math.Ceiling((double)people / capacity);

            Console.WriteLine(trips);
        }
    }
}
