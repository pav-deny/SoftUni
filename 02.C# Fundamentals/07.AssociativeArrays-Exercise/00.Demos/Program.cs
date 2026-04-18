namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new()
            {
                {"Hi", "BB"},
                {"Har Har", "MEee" }
            };

            string yo = dic["Har Har"];
            Console.WriteLine(yo);
        }
    }
}
