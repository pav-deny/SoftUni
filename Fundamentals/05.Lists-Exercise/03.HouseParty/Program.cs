namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                bool isOnList = false;
               
                if (input[2] == "going" || input[2] == "going!")//"{name} is going!"
                {
                    for (int j = 0; j < guests.Count; j++)
                    {
                        if (guests[j] == input[0])
                        {
                            isOnList = true;
                            break;
                        }
                    }

                    if (isOnList)
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(input[0]);
                    }
                }
                else if (input[2] == "not") //"{name} is not going!"
                {
                    for (int j = 0; j < guests.Count; j++)
                    {
                        if (guests[j] == input[0])
                        {
                            isOnList = true;
                            break;
                        }
                    }

                    if (!isOnList)
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                    else
                    {
                        guests.Remove(input[0]);
                    }
                }
            }

           for (int i = 0;i < guests.Count ;i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
