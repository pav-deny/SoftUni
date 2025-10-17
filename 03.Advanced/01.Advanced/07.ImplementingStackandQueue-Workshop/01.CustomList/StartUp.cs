using CustomList;
using CustomLinkedList;

namespace Project
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            MyLinkedList linked = new();

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    linked.AddFirst(i);

                else
                    linked.AddLast(i);
            }

            MyList list = new();

            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.RemoveAt(2);
        }
    }
}
