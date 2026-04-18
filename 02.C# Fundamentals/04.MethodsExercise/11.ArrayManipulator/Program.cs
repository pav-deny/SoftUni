namespace _11.ArrayManipulator_old
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray(); //Reads the input and makes it into an array

            string command = Console.ReadLine();

            while (command != "end") //ReadLine and see if we are given the command "end" - if we are don't do the while loop
            {
                string[] arguments = command.Split(); //Makes an array out of the command "exchange 1" -> "exchange", "1";
                switch (arguments[0]) //See what command is given e.g. exchange, min, max etc.
                {
                    case "exchange":
                        int index = int.Parse(arguments[1]); //Get the index e.g. exchange *1*, exchange *2*

                        bool isValidIndex = CheckIndex(index, nums.Length); //Checks if the index is valid
                        if (isValidIndex)
                        {
                            nums = ExchangeArray(nums, index); //Does the exchange
                            break;
                        }
                        break;

                    case "max":
                        string maxType = arguments[1]; //Finds if we are searching for the max even or odd number
                        GetMax(nums, maxType);
                        break;

                    case "min":
                        string minType = arguments[1];//Finds if we are searching for the max even or odd number
                        GetMin(nums, minType);
                        break;

                    case "first":

                        int firstCount = int.Parse(arguments[1]); //Gets the count of the first numbers we need to get
                        string firstType = arguments[2];

                        bool isValidCount = CheckCount(firstCount, nums.Length);

                        if (isValidCount)
                        {
                            GetFirst(nums, firstType, firstCount);
                        }
                        break;

                    case "last":

                        int lastCount = int.Parse(arguments[1]); //Gets the count of the last numbers we need to get
                        string lastType = arguments[2];

                        isValidCount = CheckCount(lastCount, nums.Length);

                        if (isValidCount)
                        {
                            GetLast(nums, lastType, lastCount);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]"); //Outputs the final form of the array

        }

        //Command methods
        static int[] ExchangeArray(int[] nums, int index)
        {
            int currentIndex = 0;
            int[] changedArray = new int[nums.Length];

            for (int i = index + 1; i < nums.Length; i++)//The for loop starts with index + 1 so that we start from the beginning of changedArray and the numbers of the old array (nums) that are after the index
            {
                changedArray[currentIndex] = nums[i]; //changedArray[0] = nums[2] (if index = 1)
                currentIndex++; //currentIndex gets bigger and then i gets bigger
            }
            for (int i = 0; i <= index; i++) //i is now 0 so that we can move the numbers from the old array before the index to the end of the new array in order
            {
                changedArray[currentIndex] = nums[i]; //changedArray[3] = nums[0] (if index = 1 and the arrays are 5 long)
                currentIndex++; //current index gets bigger and then i gets bigger
            }

            return changedArray; //Returns the exchanged array
        }

        static void GetMax(int[] nums, string type)
        {
            int maxIndex = -1; //Makes the index nonexistent so that later we can see if there are no max even/odd numbers
            int maxNum = int.MinValue; //will store the max number

            for (int i = 0; i < nums.Length; i++) //Goes through the array
            {
                if (CheckIfEvenOrOdd(nums[i], type))
                {
                    if (nums[i] >= maxNum) //If its bigger than the max number make it the max number
                    {
                        maxNum = nums[i];
                        maxIndex = i;
                    }
                }
            }

            PrintIndex(maxIndex);

        }

        static void GetMin(int[] nums, string type)
        {
            int minIndex = -1; //Makes the index nonexistent so that later we can see if there are no max even/odd numbers
            int minNum = int.MaxValue; //will store the min number

            for (int i = 0; i < nums.Length; i++) //Goes through the array
            {
                if (CheckIfEvenOrOdd(nums[i], type))
                {
                    if (nums[i] <= minNum) //If its smaller than the min number make it the min number
                    {
                        minNum = nums[i];
                        minIndex = i;
                    }
                }
            }

            PrintIndex(minIndex);

        }

        static void GetFirst(int[] nums, string type, int count)
        {
            int currentCount = 0; //Counter
            string first = ""; //Creates the array in which we will put the first *x* numbers

            if (count == 0)//If we need to find the first 0 elements print "[]"
            {
                Console.WriteLine("[]");
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (CheckIfEvenOrOdd(nums[i], type))
                {
                    first += $"{nums[i]}, ";
                    currentCount++;

                    if (currentCount >= count) //If we reach the limit
                    {
                        break;
                    }
                }


            }
            Console.WriteLine($"[{first.Trim(' ', ',')}]");
        }

        static void GetLast(int[] nums, string type, int count)
        {
            int currentCount = 0;//Counter
            string last = "";//Creates the array in which we will put the last 8x* numbers

            if (count == 0)//If we need to find the last 0 elements print "[]"
            {
                Console.WriteLine("[]");
                return;
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (CheckIfEvenOrOdd(nums[i], type))
                {
                    last = $"{nums[i]}, " + last;
                    currentCount++;
                }
                if (currentCount >= count)//If we reach the limit
                {
                    break;
                }
            }

            Console.WriteLine($"[{last.Trim(' ', ',')}]");
        }

        //Other /common/ methods

        static bool CheckIndex(int index, int indexMax) //Checks if the index is valid
        {
            if (index >= 0 && index < indexMax)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid index");
                return false;
            }
        }

        static bool CheckCount(int count, int maxCount) //Checks if the index is valid
        {
            if (count >= 0 && count <= maxCount)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid count");
                return false;
            }
        }

        static bool CheckIfEvenOrOdd(int num, string type)
        {
            return (num % 2 == 0 && type == "even") || (num % 2 != 0 && type == "odd");
            //Checks if the number is even or odd and if that corresponds to the type of number we want (even or odd)
        }
        static void PrintIndex(int index)
        {
            if (index == -1) //If we didn't find a max number
            {
                Console.WriteLine("No matches");
            }

            else //If we found a max number
            {
                Console.WriteLine(index);
            }
        }
    }
}

