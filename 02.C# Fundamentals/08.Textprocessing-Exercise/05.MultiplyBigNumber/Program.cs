namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            string result = Multiply(bigNum, multiplier);
            Console.WriteLine(result);
        }

        static string Multiply(string bigNum, int multiplier)
        {
           if (CheckIfZero(bigNum, multiplier))
           {
                return "0";
           }

           string result = string.Empty;
            int caryover = 0;

            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(bigNum[i].ToString());

                int currentResult = (currentDigit * multiplier) + caryover;

                if (currentResult >= 10)
                {
                    caryover = currentResult / 10;
                    currentResult = currentResult % 10;
                }
                else
                {
                    caryover = 0;
                }

                result = currentResult.ToString() + result;
            }

            if (caryover > 0)
            {
                result = caryover.ToString() + result;
            }

          return result;
        }

        static bool CheckIfZero(string bigNum, int multiplier)
        {
            if (bigNum == "0" || multiplier == 0)
            {
                return true;
            }

            return false;
        }
    }
}
