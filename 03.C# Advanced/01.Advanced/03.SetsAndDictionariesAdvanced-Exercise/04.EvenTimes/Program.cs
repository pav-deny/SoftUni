namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> counterDict = new();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!counterDict.ContainsKey(num))
                    counterDict[num] = 0;

                counterDict[num]++;
            }

            //foreach ((int number, int occurances) in counterDict)
            //{
            //    if (occurances % 2 == 0)
            //    {
            //        Console.WriteLine(number);
            //        return;
            //    }
            //}

            int result = counterDict.Single(kvp => kvp.Value % 2 == 0).Key;
            Console.WriteLine(result);
        }
    }
}
