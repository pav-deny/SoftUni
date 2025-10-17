namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] data1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, string> tuple1 = new($"{data1[0]} {data1[1]}", data1[2]);
            Console.WriteLine(tuple1.ToString());

            string[] data2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, int> tuple2 = new(data2[0], int.Parse(data2[1]));
            Console.WriteLine(tuple2.ToString());

            string[] data3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<int, double> tuple3 = new(int.Parse(data3[0]), double.Parse(data3[1]));
            Console.WriteLine(tuple3.ToString());
        }
    }
}
