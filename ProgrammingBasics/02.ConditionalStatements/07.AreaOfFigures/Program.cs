string shape = Console.ReadLine();
double area;

if (shape == "square")
{
    double side = double.Parse(Console.ReadLine());
    area = side * side;
    Console.WriteLine($"{area:f3}");
}
else if (shape == "rectangle")
{
    double side1 = double.Parse(Console.ReadLine());
    double side2 = double.Parse(Console.ReadLine());
    area = side1 * side2;
    Console.WriteLine($"{area:f3}");
}
else if (shape == "circle")
{
    double radius = double.Parse(Console.ReadLine());
    area = (radius * radius) * Math.PI;
    Console.WriteLine($"{area:f3}");
}
else if (shape == "triangle")
{
    double side = double.Parse((Console.ReadLine()));
    double height = double.Parse((Console.ReadLine()));
    area = side * height / 2;
    Console.WriteLine($"{area:f3}");
}