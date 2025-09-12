namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] equasionStr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Stack<string> equasion = new(equasionStr);

            int result = 0;
            bool isAddition = true;
            
            while (equasion.Count > 0)
            {
                string currentSymbol = equasion.Pop();

                if (currentSymbol == "+")
                {
                    isAddition = true;            
                }

                else if (currentSymbol == "-")
                {
                    isAddition = false;
                }

                else
                {
                    int num = int.Parse(currentSymbol);

                    if (isAddition)
                    {
                        result += num;    
                    }
                    else
                    {
                        result -= num;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
