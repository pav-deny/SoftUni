int tax = int.Parse(Console.ReadLine());


double shoes = tax - (tax * 0.4);
double jersey = shoes - (shoes * 0.2);
double ball = jersey / 4;
double accesories = ball / 5;

double totalPrice = tax + shoes + jersey + ball + accesories;
Console.WriteLine(totalPrice);

