namespace _08.CondensedNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray(); //Creates the array of numbers

            for (int k = 0; k < (nums.Length - 1); k++) 
            //To condense all numbers and their condensed forms until 1 num we need to do it (nums.Length - 1) times
            {
                int[] condensedNums = new int[nums.Length]; //Here we will store the condensed nums

                for (int i = 0; i < (nums.Length - 1); i++) 
                {
                    condensedNums[i] = nums[i] + nums[i + 1];
                }

                nums = condensedNums; //The nums are switched for their condensed forms
            }
            Console.WriteLine(nums[0]); //Prints the result
        }
    }
}
