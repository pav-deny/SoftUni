namespace GenericScale
{
    public class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<int> es = new EqualityScale<int>(6, 6);

            Console.WriteLine(es.AreEqual());
        }
    }
}
