namespace RegularMidExam
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Fundamentals May 2025 Mid Practical Exam Results:\n");

            Console.WriteLine("Start time: 09:00; End time: 13:00");
            Console.WriteLine("Started at: 09:00; Ended at: 10:27");

            Console.WriteLine("Break: 1 bathroom break (before 10:00)");
            Console.WriteLine("\nExam made in: 1 hour 27 minutes\n/-15 minute bathroom/\n1 hour 12 minutes\n");

            Console.WriteLine("Points:\n1: 30/100; 100/100\n2: 100/100\n3: 100/100\n----------\nTotal Points: 300/300\n");
            Console.WriteLine("Mistakes:\n1: {:f2} was accidentally deleted\n2: none\n3: none");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine("1.Cooking masterclass");
            Console.WriteLine("It wasn't hard and it wasn't too long\n\n");

            Console.WriteLine("2.FriendlistMaintnance");
            Console.WriteLine("It wasn't hard, but it was long\n\n");

            Console.WriteLine("3.ChatLogger");
            Console.WriteLine("It wasn't hard and it was really short\n");

            Console.WriteLine("Press 's' to go back to the statistics screen\nPress any other key to end");
            char key = char.Parse(Console.ReadLine());

            if (key == 's')
            {
                Main();
            }
        }
    }
}
