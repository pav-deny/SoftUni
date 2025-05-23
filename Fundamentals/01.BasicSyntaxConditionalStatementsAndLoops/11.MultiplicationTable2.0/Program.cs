using System.Xml;

namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            do
            {
                int result = num * times;

                Console.WriteLine($"{num} X {times} = {result}");
                times++;
            }
            while (times <= 10);
        }
    }
}
