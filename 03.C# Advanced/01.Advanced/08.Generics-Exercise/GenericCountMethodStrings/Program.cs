namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new();

            for (int i = 0; i < n; i++)
            {
               string element = Console.ReadLine();
                list.Add(element);
            }

            string value = Console.ReadLine();

            Console.WriteLine(CountGrater(list, value));
        }

        static int CountGrater<T>(List<T> list, T value)
        {
            int count = 0;

            foreach (T element in list)
            {
                int result = Comparer<T>.Default.Compare(element, value);

                if (result > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
