namespace Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] data1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string town = string.Join(" ", data1.Skip(3));
            CustomTuple<string, string, string> tuple1 = new($"{data1[0]} {data1[1]}", data1[2], town);
            Console.WriteLine(tuple1.ToString());

            string[] data2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isDrunk = data2[2] == "drunk" ? true : false;
            CustomTuple<string, int, bool> tuple2 = new(data2[0], int.Parse(data2[1]), isDrunk);
            Console.WriteLine(tuple2.ToString());

            string[] data3 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CustomTuple<string, double, string> tuple3 = new(data3[0], double.Parse(data3[1]), data3[2]);
            Console.WriteLine(tuple3.ToString());
        }
    }
}
