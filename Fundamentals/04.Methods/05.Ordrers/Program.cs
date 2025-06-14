namespace _05.Ordrers
{
    internal class Program
    {
        static void Main()
        {
            string item = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            SetPrice(item, quantity);
        }

        static void SetPrice(string item, int quantity = 1)
        {
            decimal singlePrice = 1;

            switch (item)
            {
                case "coffee":
                    singlePrice = 1.50m;
                    break;

                case "water":
                    singlePrice = 1.00m;
                    break;

                case "coke":
                    singlePrice = 1.40m;
                    break;

                case "snacks":
                    singlePrice = 2.00m;
                    break;
            }

            decimal totalPrice = singlePrice * quantity;

            PrintPrice(totalPrice);
        }

        static void PrintPrice (decimal totalPrice)
        {
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
