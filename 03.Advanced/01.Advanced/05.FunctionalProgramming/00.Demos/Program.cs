using System;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Func<int, int> sqr = x => x * x;

            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine(string.Join(", ", Select(arr, x => x * x)));
        }

        static int[] Select(int[] arr, Func<int, int> sqr)
        {
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = sqr(arr[i]);
            }

            return result;
        }
    }
}
