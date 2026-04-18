namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string peopleType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double singlePrice = 0;
            double totalPrice = 0;

            if (peopleType == "Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        singlePrice = 8.45;
                        break;
                    case "Saturday":
                        singlePrice = 9.80;
                        break;
                    case "Sunday":
                        singlePrice = 10.46;
                        break;
                }

                totalPrice = singlePrice * peopleCount;

                if (peopleCount >= 30)
                {
                    totalPrice -= totalPrice * 0.15;
                }
            }
            else if (peopleType == "Business")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        singlePrice = 10.90;
                        break;
                    case "Saturday":
                        singlePrice = 15.60;
                        break;
                    case "Sunday":
                        singlePrice = 16.00;
                        break;
                }

                if (peopleCount >= 100)
                {
                    peopleCount -= 10;
                }

                totalPrice = singlePrice * peopleCount;
            }
            else if (peopleType == "Regular")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        singlePrice = 15.00;
                        break;
                    case "Saturday":
                        singlePrice = 20.00;
                        break;
                    case "Sunday":
                        singlePrice = 22.50;
                        break;
                }

                totalPrice = singlePrice * peopleCount;

                if (peopleCount >= 10 && peopleCount <= 20)
                {
                    totalPrice -= totalPrice * 0.05;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
