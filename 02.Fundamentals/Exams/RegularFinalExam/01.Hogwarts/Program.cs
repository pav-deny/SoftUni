namespace _01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Abracadabra")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "Abjuration":
                        spell = spell.ToUpper();
                        Console.WriteLine(spell);
                        break;

                    case "Necromancy":
                        spell = spell.ToLower();
                        Console.WriteLine(spell);
                        break;

                    case "Illusion":
                        int index = int.Parse(commandArgs[1]);
                        string letter = commandArgs[2];

                        if (!CheckIndex(spell, index))
                        {
                            Console.WriteLine("The spell was too weak.");
                            break;
                        }

                        spell = ChangeLetterAtIndex(spell, index, letter);
                        Console.WriteLine("Done!");
                        break;

                    case "Divination"://If wrong answer check this
                        string firstSubstring = commandArgs[1];
                        string secondSubstring = commandArgs[2];

                        if (spell.Contains(firstSubstring))
                        {
                            spell = spell.Replace(firstSubstring, secondSubstring);
                            Console.WriteLine(spell);
                        }
                        break;

                    case "Alteration":
                        string subststring = commandArgs[1];
                        if (spell.Contains(subststring))
                        {
                            spell = RemoveSubstring(spell, subststring);
                            Console.WriteLine(spell);
                        }
                      
                        break;

                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
            }
        }

        static string ChangeLetterAtIndex(string oldSpell, int index, string letter)
        {
            string prefix = oldSpell.Substring(0, index);
            string suffix = oldSpell.Substring(index + 1);

            string newSpell = prefix + letter + suffix;

            return newSpell;
        }

        static string RemoveSubstring(string oldSpell, string substring)
        {
            int index = oldSpell.IndexOf(substring);

            if (index == -1)
            {
                return oldSpell;
            }

            string newSpell = oldSpell.Remove(index, substring.Length);
            /*Console.WriteLine(newSpell);*///If its a wrong answer check this
            return newSpell;
        }

        static bool CheckIndex(string spell, int index)
        {
            if (index >= 0 && index < spell.Length)
            {
                return true;
            }

            return false;
        }
    }
}
