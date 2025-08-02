double recordInSeconds = double.Parse(Console.ReadLine());
double metersToSwim = double.Parse(Console.ReadLine());
double secondsPerMeter = double.Parse(Console.ReadLine());

double swimSecondsNoDelay = metersToSwim * secondsPerMeter;

double delayTimes = Math.Floor(metersToSwim / 15);
double swimSeconds = swimSecondsNoDelay + delayTimes * 12.5;

if (swimSeconds < recordInSeconds)
{
    Console.WriteLine($"Yes, he succeeded! The new world record is {swimSeconds:f2} seconds.");
}
else
{
    double difference = recordInSeconds - swimSeconds;
    difference = Math.Abs(difference);
    Console.WriteLine($"No, he failed! He was {difference:f2} seconds slower.");
}
