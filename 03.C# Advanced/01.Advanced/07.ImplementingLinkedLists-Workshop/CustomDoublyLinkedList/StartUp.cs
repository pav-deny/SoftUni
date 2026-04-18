namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddLast(4);

            list.AddFirst(1);
            list.AddLast(5);

            list.AddLast(6);
            list.AddFirst(0);

            list.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"Count: {list.Count}");

            Console.WriteLine("=====================");

            list.RemoveLast();
            list.RemoveFirst();

            list.ForEach(n => Console.WriteLine(n));
            Console.WriteLine($"Count: {list.Count}");

            Console.WriteLine("=====================");

            int[] arr = list.ToArray();
            Console.WriteLine($"{String.Join(", ", arr)}\nCount: {list.Count}");
        }
    }
}
