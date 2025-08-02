int chicken = int.Parse(Console.ReadLine());
int fish = int.Parse(Console.ReadLine());
int vegetarian = int.Parse(Console.ReadLine());

double chickenPrice = chicken * 10.35;
double fishPrice = fish * 12.4;
double vegeterianPrice = vegetarian * 8.15;

double mealPrice = chickenPrice + fishPrice + vegeterianPrice;
double desertPrice = mealPrice * 0.2;
double totalPrice = 2.5 + mealPrice + desertPrice;

Console.WriteLine(totalPrice);
