namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            rotations %= arr.Length;

            int[] tempArr = new int[arr.Length];
            int index = 0;

            for (int i = rotations; i < arr.Length; i++)
            {
                tempArr[index] = arr[i];
                index++;
            }

            for (int i = 0; i < rotations; i++)
            {
                tempArr [index] = arr[i];
                index++;
            }

            arr = tempArr;

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
