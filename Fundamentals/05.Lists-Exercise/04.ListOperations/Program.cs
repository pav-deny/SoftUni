using System.Collections.Concurrent;
using System.Net;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> arguments = input.Split().ToList();

                switch (arguments[0])
                {
                    case "Add":
                        int numToAdd = int.Parse(arguments[1]);
                        list.Add(numToAdd);
                        break;

                    case "Insert":
                        int numToInsert = int.Parse(arguments[1]);
                        int insertIndex = int.Parse(arguments[2]);

                        if (CheckIndex(list, insertIndex))
                        {
                            list.Insert(insertIndex, numToInsert);
                        }

                        break;

                    case "Remove":
                        int removeIndex = int.Parse(arguments[1]);

                        if (CheckIndex(list, removeIndex))
                        {
                            list.RemoveAt(removeIndex);
                        }

                            break;

                    case "Shift":
                        string direction = arguments[1];
                        int count = int.Parse(arguments[2]);

                        if (direction == "left")
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int temp = list[0];
                                list.RemoveAt(0);
                                list.Add(temp);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                int temp = list[list.Count - 1];
                                list.RemoveAt(list.Count - 1);
                                list.Insert(0, temp);
                            }
                        }
                            break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static bool CheckIndex (List<int> list,int index)
        {
            if (index < list.Count && index >= 0)
            {
                return true;
            }

            Console.WriteLine("Invalid index");
            return false;
        }
    }
}
