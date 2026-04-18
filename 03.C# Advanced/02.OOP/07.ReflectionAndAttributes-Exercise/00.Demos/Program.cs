using System.Reflection;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new() { 1, 2 };

            Console.WriteLine(ints.Count);

            FieldInfo size = ints.GetType().GetField("_size", BindingFlags.Instance | BindingFlags.NonPublic);
            size.SetValue(ints, 6);

            Console.WriteLine(ints.Count);
        }
    }
}
