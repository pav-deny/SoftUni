namespace _03.ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            bool firstArrIsFirst = true;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (firstArrIsFirst)
                {
                    arr1[i] = input[0];
                    arr2[i] = input[1];
                    firstArrIsFirst = false;
                }
                else
                {
                    arr1[i] = input[1];
                    arr2[i] = input[0];
                    firstArrIsFirst = true;
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
