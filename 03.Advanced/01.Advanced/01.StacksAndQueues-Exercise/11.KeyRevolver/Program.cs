namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> locks = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int intelegenceVal = int.Parse(Console.ReadLine());

            int currentBarrel = gunBarrelSize, shotsFired = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets.Pop(), currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                shotsFired++;
                currentBarrel--;

                if (currentBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = gunBarrelSize;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = intelegenceVal - (shotsFired * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
