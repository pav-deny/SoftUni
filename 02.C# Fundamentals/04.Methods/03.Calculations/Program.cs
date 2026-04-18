namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (action)
            {
                case "add":
                    AddNums(num1, num2);
                    break;

                case "subtract":
                    SubtractNums(num1, num2);
                    break;

                case "multiply":
                    MultiplyNums(num1, num2);
                    break;

                case "divide":
                    DivideNums(num1, num2);
                    break;
            }

        }

        static void AddNums(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void SubtractNums(int num1, int num2)
        {
            Console.WriteLine(num1 - num2);
        }

        static void MultiplyNums(int num1, int num2)
        {
            Console.WriteLine(num1 * num2);
        }

        static void DivideNums(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }
    }
}
