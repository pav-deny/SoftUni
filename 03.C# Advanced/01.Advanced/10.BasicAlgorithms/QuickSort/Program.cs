namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            QuickSort<int> sorter = new QuickSort<int>();
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class QuickSort<T> where T : IComparable<T>
    {
        private T[] aux;

        public void Sort(T[] array)
        {
            if (array.Length <= 1) return; // nothing to sort
            aux = new T[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int left, int right)
        {
            if (left >= right) return; // base case

            int mid = (left + right) / 2;

            Sort(array, left, mid);
            Sort(array, mid + 1, right);
            Merge(array, left, mid, right);
        }

        private void Merge(T[] array, int left, int mid, int right)
        {
            // Optimization: already sorted
            if (array[mid].CompareTo(array[mid + 1]) <= 0)
            {
                return;
            }

            // Copy to auxiliary array
            for (int i = left; i <= right; i++)
            {
                aux[i] = array[i];
            }

            int iLeft = left;
            int iRight = mid + 1;

            for (int k = left; k <= right; k++)
            {
                if (iLeft > mid)
                {
                    array[k] = aux[iRight++];
                }
                else if (iRight > right)
                {
                    array[k] = aux[iLeft++];
                }
                else if (aux[iLeft].CompareTo(aux[iRight]) <= 0)
                {
                    array[k] = aux[iLeft++];
                }
                else
                {
                    array[k] = aux[iRight++];
                }
            }
        }
    }
}
