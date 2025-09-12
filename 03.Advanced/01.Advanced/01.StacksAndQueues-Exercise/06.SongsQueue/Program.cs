namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WE MAKING SPOTIFY 2 BABY
            Queue<string> songs = new(ReadSongs());

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                
                if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }

                else if (command == "Play")
                {
                    songs.Dequeue();
                }

                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }

        private static Queue<string> ReadSongs()
        {
            IEnumerable<string> sequence = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            return new Queue<string>(sequence);
        }
    }
}
