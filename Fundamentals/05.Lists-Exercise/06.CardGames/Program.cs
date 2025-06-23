namespace _06.CardGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hand1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> hand2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            

            while (hand1.Count > 0 && hand2.Count > 0)
            {
                int temp = 0;
                int player1Card = hand1[0];
                int player2Card = hand2[0];

                if (player1Card > player2Card)
                {
                    temp = hand1[0];
                    hand1.RemoveAt(0);
                    hand1.Add(temp);
                    hand1.Add(hand2[0]);
                    hand2.RemoveAt(0);
                }

                else if (player1Card < player2Card)
                {
                    temp = hand2[0];
                    hand2.RemoveAt(0);
                    hand2.Add(temp);
                    hand2.Add(hand1[0]);
                    hand1.RemoveAt(0);
                }

                else if (player1Card == player2Card)
                {
                    hand1.RemoveAt(0);
                    hand2.RemoveAt(0);
                }
            }

            string winner = string.Empty;
            int sum = 0;

            if (hand1.Count > 0)
            {
                winner = "First";
                sum = hand1.Sum();
            }
            else if (hand2.Count > 0)
            {
                winner = "Second";
                sum = hand2.Sum();
            }

            Console.WriteLine($"{winner} player wins! Sum: {sum}");
        }
    }
}
