namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWinDurartion = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new();
            int carsPassed = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int timeLeft = greenDuration;

                    while (timeLeft > 0 && carsQueue.Count > 0)
                    {
                        string currentCar = carsQueue.Dequeue();

                        if (currentCar.Length <= timeLeft)
                        {
                            carsPassed++;
                            timeLeft -= currentCar.Length;
                        }
                        else
                        {
                            int lengthLeft = currentCar.Length - timeLeft;
                            
                            if (lengthLeft <= freeWinDurartion)
                            {
                                carsPassed++;
                            }
                            else
                            {
                                char hitAt = currentCar[timeLeft + freeWinDurartion];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {hitAt}.");
                                return;
                            }

                            timeLeft = 0;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
