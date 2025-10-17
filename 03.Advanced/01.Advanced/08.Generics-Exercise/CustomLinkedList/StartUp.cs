namespace CustomLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new();

            list.AddFirst("Joe");
            list.AddFirst("MAMA");

            string[] array = list.ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
