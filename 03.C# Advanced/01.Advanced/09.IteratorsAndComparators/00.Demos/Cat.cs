namespace _00.Demos
{
    public class Cat: IComparable<Cat>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Cat()
        {

        }

        public int CompareTo(Cat otherCat)
        {
            if (this.Age < otherCat.Age) return -1;
            
            else if (this.Age == otherCat.Age) return 0;

            return 1;
        }
    }
}
