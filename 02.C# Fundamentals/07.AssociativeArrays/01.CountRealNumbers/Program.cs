namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            SortedDictionary<double, int> numsCounts = new();

            foreach(double num in nums)
            {
                if (numsCounts.ContainsKey(num))
                {
                    numsCounts[num]++;
                }
                else
                {
                    numsCounts[num] = 1;
                }
            }

           foreach (KeyValuePair<double, int> numberCount in numsCounts)
            {
                Console.WriteLine($"{numberCount.Key} -> {numberCount.Value}");
            }
        }
    }
}
