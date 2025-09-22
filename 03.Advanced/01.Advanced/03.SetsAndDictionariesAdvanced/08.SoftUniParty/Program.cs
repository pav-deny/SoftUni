namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new();

            string guestInfo = string.Empty;
            while ((guestInfo = Console.ReadLine()) != "PARTY")
                guests.Add(guestInfo);

            string guestEntry = string.Empty;
            while ((guestEntry = Console.ReadLine()) != "END")
                guests.Remove(guestEntry);

            Console.WriteLine(guests.Count);

            foreach (string vipGuest in guests.Where(x => char.IsDigit(x[0])))
                Console.WriteLine(vipGuest);

            foreach (string regularGuest in guests.Where(x => !char.IsDigit(x[0])))
                Console.WriteLine(regularGuest);
        }
    }
}
