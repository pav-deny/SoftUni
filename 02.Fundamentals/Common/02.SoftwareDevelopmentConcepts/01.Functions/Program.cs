namespace _01.Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            Func<int, int> sqrd = a => a * a;

            //This is the same as:
            /*
             static int Square(int a)
            {
                return a * a;
            }
             */

            int b = sqrd(a); 

            Console.WriteLine(b);
        }
    }
}
