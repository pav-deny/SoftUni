namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0, rightSum = 0;
            bool hasEqualSum = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if ((i + 1) >= 0 && (i + 1) <= arr.Length)
                {
                    for (int j = (i + 1); j < arr.Length; j++)
                    {
                        rightSum += arr[j];
                    }
                }

                if ((i - 1) >= 0 && (i - 1) <= arr.Length)
                {
                    for (int j = (i - 1); j < arr.Length; j++)
                    {
                        leftSum += arr[j];
                    }
                }

                if (rightSum == leftSum)
                {
                    hasEqualSum = true;
                    Console.WriteLine(i);
                    break;
                }
                
            }

            if (!hasEqualSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
