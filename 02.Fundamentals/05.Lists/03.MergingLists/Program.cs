
namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            int resultCount = nums1.Count > nums2.Count ? nums1.Count : nums2.Count;

            List<int> mergedLists = new();

            for (int i = 0; i < resultCount; i++)
            {
                if(nums1.Count > i)
                {
                    mergedLists.Add(nums1[i]);
                }
                
                if (nums2.Count > i)
                {
                    mergedLists.Add(nums2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedLists));
        }
    }
}
