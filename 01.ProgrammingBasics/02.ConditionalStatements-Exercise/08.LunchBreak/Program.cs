//Input
string seriesName = Console.ReadLine();
int episodeLenght = int.Parse(Console.ReadLine());
int breakLenght = int.Parse(Console.ReadLine());

//Calculations
double lunchTime = breakLenght / 8.0;
double freeTime = breakLenght / 4.0;
double allNeededTime = lunchTime + freeTime + episodeLenght;

//Output
if (allNeededTime <= breakLenght)
{
    double remainingTime = Math.Ceiling(breakLenght - allNeededTime);
    Console.WriteLine($"You have enough time to watch {seriesName} and left with {remainingTime} minutes free time.");
}
else
{
    double remainingTime = Math.Ceiling(allNeededTime - breakLenght);
    Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {remainingTime} more minutes.");
}