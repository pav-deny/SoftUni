using System.Collections;

namespace _00.Demos
{
    public class CatsCollection : IEnumerable<Cat>
    {
        private List<Cat> cats;
        public CatsCollection()
        {
            cats = new List<Cat>();
        }

        public void Add(Cat cat)
        {
            cats.Add(cat);
        }

        public IEnumerator<Cat> GetEnumerator()
        {
           foreach (Cat cat in this.cats)
            {
                yield return cat;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //private class CatEnumarator : IEnumerator<Cat>
        //{
        //    private List<Cat> cats;
        //    private int index;

        //    public CatEnumarator(List<Cat> cats)
        //    {
        //        this.cats = cats;
        //        Reset();
        //    }

        //    public Cat Current
        //    {
        //        get { return cats[index]; }
        //    }

        //    object IEnumerator.Current => Current;

        //    public void Dispose()
        //    {

        //    }

        //    public bool MoveNext()
        //    {
        //        index++;

        //        if (index >= cats.Count)
        //            return false;

        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        index = -1;
        //    }

        //}
    }
}
