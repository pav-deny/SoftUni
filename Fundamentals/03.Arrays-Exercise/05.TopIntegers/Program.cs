namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            bool isTop = true;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = (i + 1); j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        isTop = true;
                    }
                    else
                    {
                        isTop = false;
                        break;
                    }
                }

                if (isTop)
                {
                    Console.Write($"{arr[i]} ");
                }

                isTop = true;
            }
        }
    }
}
