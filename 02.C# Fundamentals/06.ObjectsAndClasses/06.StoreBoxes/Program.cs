namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new();
            List<Box> boxes = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemData = input.Split();

                Item item = new()
                {
                    Name = itemData[1],
                    Price = decimal.Parse(itemData[3])
                };

                items.Add(item);

                Box box = new()
                {
                    SerialNumber = itemData[0],
                    Item = item,
                    ItemQuantity = int.Parse(itemData[2]),
                };

                boxes = Box.SortByPrice(boxes, box);
            }

            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        public Box()
        {
           Item = new Item();
        }

        public string SerialNumber  { get; set; }
        public Item Item {  get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForBox { get { return ItemQuantity * Item.Price;} }

        public static List<Box> SortByPrice(List<Box> boxes, Box box)
        {
            int boxesCount = boxes.Count;

            if (boxesCount == 0)
            {
                boxes.Add(box);
                return boxes;
            }

            for (int i = 0; i < boxesCount; i++)
            {
                if (boxes[i].PriceForBox < box.PriceForBox)
                {
                    boxes.Insert(i, box);
                    return boxes;
                }
            }

            boxes.Add(box);
            return boxes;
        }
    }
}
