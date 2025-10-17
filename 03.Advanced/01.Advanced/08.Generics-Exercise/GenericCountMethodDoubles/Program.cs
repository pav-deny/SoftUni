namespace GenericCountMethodDoubles
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                list.Add(element);
            }

            double value = double.Parse(Console.ReadLine());

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
