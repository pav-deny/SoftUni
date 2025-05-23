namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int hour = int.Parse(Console.ReadLine());
           int minute = int.Parse(Console.ReadLine());

            minute += 30;

            if (minute >= 60)
            {
                minute -= 60;
                hour++;
            }
            
            if (hour >= 24)
            {
                hour -= 24;
            }

            Console.WriteLine($"{hour}:{minute:d2}");
          
        }
    }
}
