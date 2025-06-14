namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //E - O always!            
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray(); //Gets the numbers and separates them in an array
            int sumOfEven = 0, sumOfOdd = 0; //The sums of even and odd nums are stored in these 2

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    sumOfEven += nums[i]; //If even add to the even sum
                }
                else
                {
                    sumOfOdd += nums[i]; //If odd add to the odd sum
                }
            }

            int subtraction = sumOfEven - sumOfOdd;
            Console.WriteLine(subtraction);
        }
    }
}

