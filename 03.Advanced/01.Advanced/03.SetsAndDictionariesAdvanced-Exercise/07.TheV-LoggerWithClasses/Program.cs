namespace _07.TheV_LoggerWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggersMap = new();
        }
    }

    public class Vlogger
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Followers = new HashSet<string>();
            Following = new HashSet<string>();
        }
    }
}
