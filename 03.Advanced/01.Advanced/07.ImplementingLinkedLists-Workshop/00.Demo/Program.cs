LinkedList<int> nums = new();

nums.AddFirst(10);
nums.AddLast(15);
nums.AddLast(8);
nums.AddLast(3);
nums.AddLast(100);
nums.AddLast(234);
nums.AddFirst(24);

Console.WriteLine(nums.Count);

Console.WriteLine("----------------------------------");

nums.RemoveLast();
Console.WriteLine(nums.Count);
Console.WriteLine("----------------------------------");

nums.RemoveFirst();
Console.WriteLine(nums.Count);
Console.WriteLine("----------------------------------");

LinkedListNode<int> firstNode = nums.First;
LinkedListNode<int> lastNode = nums.Last;

Console.WriteLine(firstNode.Value);
Console.WriteLine(lastNode.Value);
Console.WriteLine(lastNode.Previous.Previous.Value);

Console.WriteLine("----------------------------------");

LinkedListNode<int> currentNode = nums.First;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Next;
}

Console.WriteLine("----------------------------------");

currentNode = nums.Last;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Previous;
}

Console.WriteLine("----------------------------------");

foreach (int node in nums)
{
    Console.WriteLine(node);
}