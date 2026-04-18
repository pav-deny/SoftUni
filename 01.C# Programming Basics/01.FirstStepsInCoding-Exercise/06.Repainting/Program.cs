int bag = int.Parse(Console.ReadLine());
int paint = int.Parse(Console.ReadLine());
int razreditel = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double bagPrice = (bag + 2) * 1.5;
double paintPercent = paint * 0.1;
double paintPrice = (paint + paintPercent) * 14.5;
double razreditelPrice = razreditel * 5;

double totalMatPrice = bagPrice + paintPrice + razreditelPrice + 0.4;
double workPricePercent = totalMatPrice * 0.3;
double workPrice = workPricePercent * hours;

double totalPrice = totalMatPrice + workPrice;

Console.WriteLine(totalPrice);