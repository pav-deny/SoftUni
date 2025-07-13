double deposit = double.Parse(Console.ReadLine());
int time = int.Parse(Console.ReadLine());
double lihpr = double.Parse(Console.ReadLine()) / 100;


double sum = deposit + time * ((deposit * lihpr) / 12);

Console.WriteLine(sum);
