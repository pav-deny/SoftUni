namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
         .Select(int.Parse)
         .ToArray();

            MergeSort<int> sorter = new MergeSort<int>();
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }

    public class MergeSort<T> where T : IComparable<T>
    {
        private T[] aux;

        public void Sort(T[] array)
        {
            if (array.Length <= 1)
                return;

            aux = new T[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;

            Sort(array, left, mid);
            Sort(array, mid + 1, right);

            Merge(array, left, mid, right);
        }

        private void Merge(T[] array, int left, int mid, int right)
        {
            if (array[mid].CompareTo(array[mid + 1]) <= 0)
            {
                return; // already sorted
            }

            // copy current segment to aux
            for (int i = left; i <= right; i++)
            {
                aux[i] = array[i];
            }

            int iLeft = left;
            int iRight = mid + 1;

            for (int i = left; i <= right; i++)
            {
                if (iLeft > mid)
                {
                    array[i] = aux[iRight++];
                }
                else if (iRight > right)
                {
                    array[i] = aux[iLeft++];
                }
                else if (aux[iLeft].CompareTo(aux[iRight]) <= 0)
                {
                    array[i] = aux[iLeft++];
                }
                else
                {
                    array[i] = aux[iRight++];
                }
            }
        }
    }
}
