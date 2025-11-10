namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    int index = int.Parse(commandArgs[1]);

                    switch (commandArgs[0])
                    {
                        case "Replace":
                            int element = int.Parse(commandArgs[2]);
                            ints[index] = element;
                            break;

                        case "Print":
                            int endIndex = int.Parse(commandArgs[2]);

                            List<int> result = new();

                            for (int i = index; i <= endIndex; i++)
                                result.Add(ints[i]);

                            Console.WriteLine(string.Join(", ", result));
                            break;

                        case "Show":
                            Console.WriteLine(ints[index]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }

            Console.WriteLine(string.Join(", ", ints));
        }
    }
}
