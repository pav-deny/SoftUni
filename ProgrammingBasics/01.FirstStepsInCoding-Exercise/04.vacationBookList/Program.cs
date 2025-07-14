int pages = int.Parse(Console.ReadLine());
int pagesperhr = int.Parse(Console.ReadLine());
int days = int.Parse(Console.ReadLine());

int totlaptime = pages / pagesperhr;
int totaltime = totlaptime / days;

Console.WriteLine(totaltime);
