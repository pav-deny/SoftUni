namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sequences = int.Parse(Console.ReadLine());
            string[] bestSequence = Array.Empty<string>();

            int bestCount = 0;
            int bestIndex = int.MaxValue;
            int bestSum = 0;
            int bestSequenceNum = 1;

            string input = string.Empty;
            int sequenceNum = 0;
            
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string[] sequence = input.Split("!", StringSplitOptions.RemoveEmptyEntries);
                int count = 0;
                int sum = 0;

                sequenceNum++;

                if (bestSequence.Length == 0)
                {
                    bestSequence = sequence;
                }

                for (int i = sequences - 1; i >= 0; i--)
                {
                    if (sequence[i] == "1")
                    {
                        sum++;
                        count++;

                        if(count > bestCount || i < bestIndex || sum > bestSum)
                        {
                            bestCount = count;
                            bestIndex = i;
                            bestSum = sum;
                            bestSequence = sequence;
                            bestSequenceNum = sequenceNum;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSequenceNum} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ",bestSequence)}");
        }
    }
}
