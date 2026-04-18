double area = double.Parse(Console.ReadLine());

double price = area * 7.61;
double discount = 0.18 * price;
double finalPrice = price - discount;

Console.WriteLine($"THe final price is: {finalPrice} lv.");
Console.WriteLine($"The discount is: {discount} lv.");