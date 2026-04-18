using System.Text;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new(data.Skip(1));

            ListyIterator<string> iterator = new ListyIterator<string>(list);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                Process(command, iterator);
            }
        }

        static void Process<T>(string command, ListyIterator<T> iterator)
        {
            try
            {
                if (command == "Move")
                {
                    bool result = iterator.Move();
                    Console.WriteLine(result);
                }
                else if (command == "HasNext")
                {
                    bool result = iterator.HasNext();
                    Console.WriteLine(result);
                }
                else if (command == "Print")
                {
                    T value = iterator.GetValue();
                    Console.WriteLine(value);
                }
                else if (command == "PrintAll")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (T element in  iterator)
                    {
                        sb.Append(element.ToString());
                        sb.Append(" ");
                    }

                    Console.WriteLine(sb.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
