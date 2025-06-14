using System;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = string.Empty;
            bool isChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> arguments = input.Split().ToList();
                int num, index;

                switch(arguments[0])
                {
                    case "Add":
                        num = int.Parse(arguments[1]);
                        nums.Add(num);
                        isChanged = true;
                        break;

                    case "Remove":
                        num = int.Parse(arguments[1]);
                        nums.Remove(num);
                        isChanged = true;
                        break;

                    case "RemoveAt":
                        index = int.Parse(arguments[1]);
                        nums.RemoveAt(index);
                        isChanged = true;
                        break;

                    case "Insert":
                        num = int.Parse(arguments[1]);
                        index = int.Parse(arguments[2]);
                        nums.Insert(index, num);
                        isChanged = true;
                        break;
                        
                    case "Contains":
                        num = int.Parse(arguments[1]);

                        if(nums.Contains(num))
                        {
                            Console.WriteLine("Yes");
                            break;
                        }

                        Console.WriteLine("No such number");
                        break;

                    case "PrintEven":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 == 0)
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "PrintOdd":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] % 2 != 0)
                            {
                                Console.Write($"{nums[i]} ");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "GetSum":
                        int sum = 0;

                        for (int i = 0; i < nums.Count; i++)
                        {
                            sum += nums[i];
                        }

                        Console.WriteLine(sum);
                        break;

                    case "Filter":
                        int conditionNum = int.Parse(arguments[2]);
                        string condition = arguments[1];
                        List<int> filteredNums = new();

                        switch (condition)
                        {
                            case ">":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] > conditionNum)
                                    {
                                        filteredNums.Add(nums[i]);
                                    }
                                }
                                break;

                            case "<":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] < conditionNum)
                                    {
                                        filteredNums.Add(nums[i]);
                                    }
                                }
                                break;

                            case ">=":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] >= conditionNum)
                                    {
                                        filteredNums.Add(nums[i]);
                                    }
                                }
                                break;

                            case "<=":
                                for (int i = 0; i < nums.Count; i++)
                                {
                                    if (nums[i] <= conditionNum)
                                    {
                                        filteredNums.Add(nums[i]);
                                    }
                                }
                                break;
                        }

                        Console.WriteLine(string.Join(" ", filteredNums));
                        break;
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
