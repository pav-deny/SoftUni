using System.Globalization;

namespace _07.MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 0, bestCount = 0, num = arr[0], bestNum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    count++;

                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestNum = num;
                    }
                }
                else
                {
                    num = arr[i];
                    count = 1;
                }
            }

            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(bestNum + " ");
            }
        }
    }
}
