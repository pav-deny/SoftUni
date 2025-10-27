namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rList = new() { "George", "Micheal", "Jim", "Bim" };

            rList.Add("Jack");
            rList.Add("Daniels");

            string removed = rList.RandomString();
            Console.WriteLine(removed);
        }
    }
}
