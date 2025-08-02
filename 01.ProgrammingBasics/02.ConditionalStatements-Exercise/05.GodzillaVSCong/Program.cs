double budget = double.Parse(Console.ReadLine());
int statist = int.Parse(Console.ReadLine());
double clothesPrice = double.Parse(Console.ReadLine());

double decor = budget * 0.1;


double totalClothesPrices = clothesPrice * statist;

if (statist >= 150)
{
    double discount = totalClothesPrices * 0.1;
    totalClothesPrices -= discount;
}

double totalSum = totalClothesPrices + decor;
double moneyLeft = totalSum - budget;
moneyLeft = Math.Abs(moneyLeft);

if (totalSum > budget)
{
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {moneyLeft:f2} leva more.");
}
else
{
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
}