namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = int.Parse(Console.ReadLine());

            Console.WriteLine(RaiseNumber(num, power));
        }

        static double RaiseNumber(double num, double power)
        {
            double raisedNum = 1;

            for (int i = 1; i <= power; i++)
            {
                raisedNum *= num;
            }

            return raisedNum;
        }
    }
}
