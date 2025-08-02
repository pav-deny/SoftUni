
using System.Diagnostics.Metrics;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();//Creates

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] arguments = input.Split();
                string type;

                switch (arguments[0])
                {
                    case "exchange":
                        int index = int.Parse(arguments[1]);

                        if (index < 0 || index >= arr.Length)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        arr = Exchange(arr, index);
                        break;

                    case "max":
                        type = arguments[1];
                        Max(arr, type);
                        break;

                    case "min":
                        type = arguments[1];
                        Min(arr, type);
                        break;

                    case "first":
                        type = arguments[2];
                        int firstCount = int.Parse(arguments[1]);

                        if (firstCount < 0 || firstCount > arr.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        First(arr, type, firstCount);
                        break;

                    case "last":
                        type = arguments[2];
                        int lastCount = int.Parse(arguments[1]);

                        if (lastCount < 0 || lastCount > arr.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        Last(arr, type, lastCount);
                        break;
                }
            }

            string output = string.Join(", ", arr);
            Console.WriteLine($"[{output.Trim(',', ' ')}]");
        }

        static int[] Exchange(int[] arr, int index)
        {
            int[] exchangedArr = new int[arr.Length];
            int currentIndex = 0;

            for (int i = index + 1; i < arr.Length; i++)
            {
                exchangedArr[currentIndex] = arr[i];
                currentIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                exchangedArr[currentIndex] = arr[i];
                currentIndex++;
            }

            return exchangedArr;
        }

        static void Max(int[] arr, string type)
        {
            int biggestNum = int.MinValue, biggestIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= biggestNum && isEvenOrOdd(arr[i], type))
                {
                    biggestIndex = i;
                    biggestNum = arr[i];
                }
            }

            if (biggestIndex < 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(biggestIndex);
            }
        }

        static void Min(int[] arr, string type)
        {
            int smallestNum = int.MaxValue, smallestIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= smallestNum && isEvenOrOdd(arr[i], type))
                {
                    smallestIndex = i;
                    smallestNum = arr[i];
                }
            }

            if (smallestIndex < 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(smallestIndex);
            }
        }

        static void First(int[] arr, string type, int count)
        {
            string first = string.Empty;
            int counter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (isEvenOrOdd(arr[i], type))
                {
                    first += $"{arr[i]}, ";
                    counter++;
                }

                if (counter >= count)
                {
                    break;
                }
            }

            Console.WriteLine($"[{first.Trim(',', ' ')}]");
        }

        static void Last(int[] arr, string type, int count)
        {
            string last = string.Empty;
            int counter = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (isEvenOrOdd(arr[i], type))
                {
                    last = $"{arr[i]}, " + last;
                    counter++;
                }

                if (counter >= count)
                {
                    break;
                }
            }

            Console.WriteLine($"[{last.Trim(',', ' ')}]");
        }

        //Other common methods
        static bool isEvenOrOdd(int num, string type)
        {
            if ((num % 2 == 0 && type == "even") || (num % 2 != 0 && type == "odd"))
            {
                return true;
            }

            return false;
        }

    }
}