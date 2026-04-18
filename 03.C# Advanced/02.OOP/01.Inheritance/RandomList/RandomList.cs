namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random;

        public RandomList()
        {
           this.random = new Random();
        }

        public string RandomString()
        {
            int index = random.Next(0, this.Count);

            string removed = this[index];
            this.RemoveAt(index);

            return removed;
        }
    }
}
