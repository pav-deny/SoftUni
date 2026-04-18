namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = s => Console.WriteLine(s);

            foreach (string s in text) 
                print(s);
        }
    }
}
