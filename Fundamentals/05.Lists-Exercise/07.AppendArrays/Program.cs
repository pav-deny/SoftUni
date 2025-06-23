namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] arrs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            List<string> newArr = ReverseAndPrintArr(arrs);

            Console.WriteLine(string.Join(" ", newArr));

        }

        static List<string> ReverseAndPrintArr(string[] arrs)
        {
            List<string> changedArr = new();

            for (int i = arrs.Length - 1; i >= 0; i--)
            {
                string[] tempArr = arrs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                changedArr.AddRange(tempArr);
            }

            return changedArr;
        }
    }
}
