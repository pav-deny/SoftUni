namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();

            for (int i = inputs.Length - 1; i >= 0; i--)
            {
                Console.Write(inputs[i] + " ");
            }
        }
    }
}
