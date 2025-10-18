using System.Runtime.CompilerServices;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Track> Tracks { get; set; }

        public MusicLibrary(string  name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            if (Tracks.Count >= Capacity || Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist))
                return;

            Tracks.Add(track);
        }

        public bool RemoveTrack(string title, string artist)
        {
            Track remove = null;

           foreach (Track track in Tracks)
           {
                if (track.Title == title && track.Artist == artist)
                    remove = track;
           }

           if (remove == null) return false;

           Tracks.Remove(remove);
            return true;
        }

        public Track GetLongestTrack()
        {
            Track longest = Tracks[0];

            foreach (Track track in Tracks)
            {
                if (track.Duration > longest.Duration) 
                    longest = track;
            }

            return longest;
        }

        public string GetTrackDetails(string title, string artist)
        {
            Track track = null;

            foreach (Track t in Tracks)
            {
                if (t.Title == title && t.Artist == artist)
                {
                    track = t;
                    break;
                }
            }

            if (track == null)
                return "Track not found!";

            return track.ToString();
        }

        public int GetTracksCount()
        {
            return Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            List<Track> matchingTracks = new();
            
            foreach (Track t in Tracks)
            {
                if (t.Genre == genre)
                    matchingTracks.Add(t);
            }

            return matchingTracks.OrderBy(t => t.Duration).ToList();
        }

        public string LibraryReport()
        {
            List<Track> orderedTracks = Tracks.OrderByDescending(t => t.Duration).ToList();

            string report = $"Music Library: {this.Name}\nTracks capacity: {this.Capacity}\nNumber of tracks added: {this.Tracks.Count}\n";

            report += "Tracks:";

            for (int i = 0; i < orderedTracks.Count; i++)
            {
                report += $"\n-{orderedTracks[i].ToString()}";
            }

            return report;
        }
    }
}
