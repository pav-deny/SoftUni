double budget = double.Parse(Console.ReadLine());
int videoCards = int.Parse(Console.ReadLine());
int CPUs = int.Parse(Console.ReadLine());
int RAM = int.Parse(Console.ReadLine());

double videoCardPrice = videoCards * 250;
double CPUprice = CPUs * (videoCardPrice * 0.35);
double RAMprice = RAM * (videoCardPrice * 0.1);
double totalPrice = videoCardPrice + CPUprice + RAMprice;


if (videoCards > CPUs)
{
    totalPrice -= totalPrice * 0.15;
}

double left = budget - totalPrice;
left = Math.Abs(left);

if (budget >= totalPrice)
{
    Console.WriteLine($"You have {left:f2} leva left!");
}
else
{
    Console.WriteLine($"Not enough money! You need {left:f2} leva more!");
}