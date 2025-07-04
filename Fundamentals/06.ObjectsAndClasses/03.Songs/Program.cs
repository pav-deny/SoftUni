using System.Threading.Channels;

namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('_');

                Song song = new()
                {
                    ListType = data[0],
                    Name = data[1],
                    Time = data[2]
                };

                songs.Add(song);
            }

            string listType = Console.ReadLine();

            if (listType == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.ListType == listType)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    public class Song
    {
        public string ListType { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
