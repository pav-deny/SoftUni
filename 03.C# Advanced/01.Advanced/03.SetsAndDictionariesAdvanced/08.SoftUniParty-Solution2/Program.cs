namespace _08.SoftUniParty_Solution2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new();
            HashSet<string> guests = new();

            string guestInfo = string.Empty;
            while ((guestInfo = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(guestInfo[0]))
                {
                    vipGuests.Add(guestInfo);
                }
                else
                {
                    guests.Add(guestInfo);
                }
            }

            string guestEntry = string.Empty;
            while ((guestEntry = Console.ReadLine()) != "END")
            {
                if (char.IsDigit(guestEntry[0]))
                {
                    vipGuests.Remove(guestEntry);
                }
                else
                {
                    guests.Remove(guestEntry);
                }
            }

            int didntCome = vipGuests.Count + guests.Count;
            Console.WriteLine(didntCome);

            foreach (string vipGuest in vipGuests)
                Console.WriteLine(vipGuest);

            foreach (string guest in guests)
                Console.WriteLine(guest);
        }
    }
}
