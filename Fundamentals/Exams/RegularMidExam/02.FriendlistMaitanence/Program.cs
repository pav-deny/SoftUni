using System.Diagnostics;
using System.Xml.Linq;

namespace _02.FriendlistMaitanence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friends = Console.ReadLine().Split(", ");

            int blacklistedNames = 0, lostNames = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Report")
            {
                string[] commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "Blacklist":
                        string name = commandArgs[1];

                        friends = BlacklistName(name, friends);
                        
                        break;

                    case "Error":
                        int index = int.Parse(commandArgs[1]);

                        friends = LooseName(index, friends);
                      
                        break;

                    case "Change":
                        int changeIndex = int.Parse(commandArgs[1]);
                        string newName = commandArgs[2];

                        friends = ChangeName(changeIndex, newName, friends);
                        break;
                }
            }


            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == "Blacklisted")
                {
                    blacklistedNames++;
                }
                else if (friends[i] == "Lost")
                {
                    lostNames++;
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNames}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", friends));

        }

        static string[] BlacklistName(string name, string[] friends)
        {

            bool nameIsFound = false;

            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == name)
                {
                    friends[i] = "Blacklisted";
                    Console.WriteLine($"{name} was blacklisted.");
                    nameIsFound = true;
                    break;
                }
            }

            if (!nameIsFound)
            {
                Console.WriteLine($"{name} was not found.");
            }

            return friends;
        }

        static string[] LooseName(int index, string[] friends)
        {
            if (CheckIndex(index, friends) && (friends[index] != "Blacklisted" && friends[index] != "Lost"))
            {
                Console.WriteLine($"{friends[index]} was lost due to an error.");
                friends[index] = "Lost";
            }

            return friends;
        }

        static string[] ChangeName(int index, string newName,  string[] friends)
        {
            if (CheckIndex(index, friends))
            {
                Console.WriteLine($"{friends[index]} changed his username to {newName}.");
                friends[index] = newName;
            }
            return friends;
        }

        static bool CheckIndex(int index, string[] friends)
        {
            if (index >= 0 && index < friends.Length)
            {
                return true;
            }

            return false;
        }
    }
}
