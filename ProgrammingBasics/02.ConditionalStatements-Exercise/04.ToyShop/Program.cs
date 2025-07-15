double vacationPrice = double.Parse(Console.ReadLine());
int puzzles = int.Parse(Console.ReadLine());
int dolls = int.Parse(Console.ReadLine());
int teddyBears = int.Parse(Console.ReadLine());
int minions = int.Parse(Console.ReadLine());
int trucks = int.Parse(Console.ReadLine());

int count = puzzles + dolls + teddyBears + minions + trucks;

double totalPrice = (puzzles * 2.6) + (dolls * 3) + (teddyBears * 4.1) + (minions * 8.2) + (trucks * 2);

if (count >= 50)
{
    totalPrice = totalPrice * 0.75;
}

double rent = totalPrice * 0.1;
double finalPrice = totalPrice - rent;

if (finalPrice >= vacationPrice)
{
    double left = finalPrice - vacationPrice;
    Console.WriteLine($"Yes! {left:f2} lv left.");
}
else
{
    double needed = finalPrice - vacationPrice;
    needed = Math.Abs(needed);
    Console.WriteLine($"Not enough money! {needed:f2} lv needed.");
}