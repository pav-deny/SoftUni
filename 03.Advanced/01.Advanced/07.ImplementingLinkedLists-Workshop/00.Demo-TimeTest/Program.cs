using System.Diagnostics;

Stopwatch stopwatch = new();

stopwatch.Start();

LinkedList<int> lList = new();

for (int i = 0; i < 100_000; i++)
{
    lList.AddFirst(i);
}

stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

stopwatch.Reset();
stopwatch.Start();

List<int> list = new();

for (int i = 0; i < 100_000; i++)
{
    list.Insert(0, i);
}

stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);

stopwatch.Reset();
stopwatch.Start();

HashSet<int> hashSet = new();

for (int i = 0; i < 100_000; i++)
{
    hashSet.Add(i);
}

stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);