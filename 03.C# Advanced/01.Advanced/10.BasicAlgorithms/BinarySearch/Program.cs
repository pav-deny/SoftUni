namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int key = int.Parse(Console.ReadLine());

            BinarySearch searcher = new BinarySearch();
            int index = searcher.Search(array, key);

            Console.WriteLine(index);
        }
    }

    public class BinarySearch
    {
        public int Search(int[] array, int key)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == key)
                    return mid;

                else if (array[mid] > key)
                    right = mid - 1;

                else 
                    left = mid + 1;
            }

            return -1;
        }
    }
}
