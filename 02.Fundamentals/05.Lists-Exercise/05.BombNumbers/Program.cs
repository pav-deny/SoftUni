namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> bombCharacterisitcs = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bomb = bombCharacterisitcs[0];
            int bombPower = bombCharacterisitcs[1];

            while (list.Contains(bomb))
            {
                int bombPosition = list.IndexOf(bomb);

                int leftIndex = Math.Max(0, bombPosition - bombPower);
                int rightIndex = Math.Min(list.Count - 1, bombPosition + bombPower);

                int range = rightIndex - leftIndex + 1;
                list.RemoveRange(leftIndex, range);
            }

            Console.WriteLine(list.Sum());
        }
    }
}
