namespace _10.RageExpensses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());

            int headsetsBroken = gamesLost / 2; //every 2nd game
            int mousesBroken = gamesLost / 3; //every third game
            int keyboardsBroken = gamesLost / 6; //every time he breaks his headset and mouse (2x3=6)
            int displaysBroken = gamesLost / 12; //every 2nd time he breaks his keyboard (6x2=12)

            double expenses = (headsetPrice * headsetsBroken) + (mousePrice * mousesBroken) + (keyboardPrice * keyboardsBroken) +  (displayPrice * displaysBroken);

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");


        }
    }
}
