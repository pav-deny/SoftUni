namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passingCarsCount = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new();
            int passedCars = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < passingCarsCount; i++)
                    {
                        if (carsQueue.Count != 0)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            passedCars++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads."); 
        }
    }
}
