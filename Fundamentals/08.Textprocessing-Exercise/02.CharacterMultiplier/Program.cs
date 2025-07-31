namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int sum = GetMultipliedsum(strings[0], strings[1]);
            
            Console.WriteLine(sum);
        }

        static int GetMultipliedsum(string string1, string string2)
        {
            int length = string1.Length > string2.Length ? string1.Length : string2.Length;

            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < string1.Length && i < string2.Length)
                {
                    sum += string1[i] * string2[i];
                }
                else if (i < string1.Length)
                {
                    sum += string1[i];
                }
                else if (i < string2.Length)
                {
                    sum += string2[i];
                }
            }

            return sum;
        }
    }
}
