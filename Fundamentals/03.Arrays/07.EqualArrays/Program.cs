namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool areDiffirent = false;
            int index = 0, sum = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    index = i;
                    areDiffirent = true;
                    break;
                }
                else
                {
                    sum += arr1[i];
                }
            }

            if (areDiffirent)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
