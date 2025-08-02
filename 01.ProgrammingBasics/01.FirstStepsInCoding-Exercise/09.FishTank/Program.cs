int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
double percent = double.Parse(Console.ReadLine()) / 100;

int volume = a * b * c; //in cm(3)
double volumeL = volume / 1000.0; //in dm3
double takenSpace = volumeL * percent; // in dm3

double waterVolume = volumeL - takenSpace;
Console.WriteLine(waterVolume);