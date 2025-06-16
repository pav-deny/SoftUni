namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArr = input.Split();
                int element = int.Parse(inputArr[1]);

                if (inputArr[0] == "Delete")
                {
                  for (int i = 0; i < ints.Count; i++)
                    {
                        if (ints[i] == element)
                        {
                            ints.RemoveAt(i);
                        }
                    }
                }
                else if (inputArr[0] == "Insert")
                {
                    int index = int.Parse(inputArr[2]);
                    ints.Insert(index, element);
                }
            }

            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
