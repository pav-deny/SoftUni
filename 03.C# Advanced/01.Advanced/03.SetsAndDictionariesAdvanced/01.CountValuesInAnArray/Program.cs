namespace _01.CountSameValuesInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Dictionary<double, int> occurances = new();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!occurances.ContainsKey(arr[i]))
                {
                    occurances[arr[i]] = 0;
                }

                occurances[arr[i]] += 1;
            }

            foreach ((double num, int occurance) in occurances)
            {
                Console.WriteLine($"{num} - {occurance} times");
            }
        }
    }
}
