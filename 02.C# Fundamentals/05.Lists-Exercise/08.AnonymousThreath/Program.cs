namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "merge":
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);

                        Merge(list, startIndex, endIndex);
                        break;

                    case "divide":
                        int index = int.Parse(commandArgs[1]);
                        int sections = int.Parse(commandArgs[2]);

                        Divide(list, index, sections);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        static List<string> Merge(List<string> list, int startIndex, int endIndex)
        {
            if (!IsInList(list, startIndex))
            {
                startIndex = 0;
            }
            if (!IsInList(list, endIndex))
            {
                endIndex = list.Count - 1;
            }

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                list[startIndex] += list[startIndex + 1];

                list.RemoveAt(startIndex + 1);
            }



            return list;
        }

        static List<string> Divide(List<string> list, int index, int sections)
        {
            if (IsInList(list, index) && sections > 0)
            {
                string @string = list[index];
                int currentChar = 0;
                int charsInSection = @string.Length / sections;
                List<string> strings = new();

                for (int i = 0; i < sections; i++)
                {
                    string newString = "";

                    for (int j = 0; j < charsInSection; j++)
                    {
                        newString += @string[currentChar];
                        currentChar++;
                    }

                    strings.Add(newString);
                }

                int charactersLeft = @string.Length % sections;

                if (charactersLeft > 0)
                {
                    for (int i = 0; i < charactersLeft; i++)
                    {
                        strings[sections - 1] += @string[currentChar];
                        currentChar++;
                    }
                }

                list.RemoveAt(index);

                for (int i = strings.Count - 1; i >= 0; i--)
                {
                    list.Insert(index, strings[i]);
                }

            }

            return list;
        }

        static bool IsInList(List<string> list, int index)
        {
            if (index < 0 || index >= list.Count)
            {
                return false;
            }

            return true;
        }
    }
}

