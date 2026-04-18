namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> arguments = input.Split().ToList();

                int num, index;

                switch (arguments[0])
                {
                    case "Add":
                        num = int.Parse(arguments[1]);
                    nums.Add(num);
                    break;

                     case "Remove":
                        num = int.Parse(arguments[1]);
                        nums.Remove(num);
                    break;

                    case "RemoveAt":
                        index = int.Parse(arguments[1]);
                        nums.RemoveAt(index);
                    break;

                    case "Insert":
                        num = int.Parse(arguments[1]);
                        index = int.Parse(arguments[2]);
                        nums.Insert(index, num);
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

