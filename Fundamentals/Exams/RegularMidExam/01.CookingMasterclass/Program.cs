namespace _01.CookingMasterclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apronPrice = decimal.Parse(Console.ReadLine());
            //Always valid

            //1 flour; 10 eggs; 1 apron
            //Apron + 20% ru
            //Every 5th flour is free

            int freeFlour = students / 5;
            
            decimal totalFlourPrice = flourPrice * (students -  freeFlour);

            decimal totalEggPrice = eggPrice * (students * 10);

            int students20Percent = (int)Math.Ceiling(students * 0.2);
            decimal totalApronPrice = apronPrice * (students + students20Percent);

            decimal totalPrice = totalFlourPrice + totalEggPrice + totalApronPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                decimal neededMoney = totalPrice - budget;
                Console.WriteLine($"{neededMoney:f2}$ more needed.");
            }
        }
    }
}
