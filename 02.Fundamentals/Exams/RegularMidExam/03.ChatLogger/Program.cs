namespace _03.ChatLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                string message = commandArgs[1];

                switch (commandArgs[0])
                {
                    case "Chat":
                        chat.Add(message);
                        break;

                    case "Delete":
                        chat.Remove(message);
                        break;

                    case "Edit":
                        string editedMessage = commandArgs[2];

                        int index = chat.IndexOf(message);
                        chat.RemoveAt(index);
                        chat.Insert(index, editedMessage);
                        break;

                    case "Pin":
                        bool isRemoved = chat.Remove(message);

                        if (isRemoved)
                        {
                            chat.Add(message);
                        }
                        break;

                    case "Spam":
                        for (int i = 1; i < commandArgs.Length; i++)
                        {
                            chat.Add(commandArgs[i]);
                        }
                        break;
                }
            }

            for (int i = 0; i < chat.Count; i++)
            {
                Console.WriteLine(chat[i]);
            }
        }
    }
}
