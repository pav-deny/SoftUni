using System.Reflection.Metadata.Ecma335;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> _list;
        private int _index;

        public ListyIterator(List<T> list)
        {
            this._list = list;
            this._index = 0;
        }

        public bool Move()
        {
            if (!HasNext())
                return false;

            this._index++;

            return true;
        }

        public bool HasNext() => ValidateIndex(this._index + 1);

        private bool ValidateIndex(int index) => (index >= 0 && index < this._list.Count);

        public void Print()
        {
            if (!ValidateIndex(this._index))
                throw new Exception("Invalid Operation!");

            Console.WriteLine(this._list[this._index]);
        }

        public T GetValue()
        {
            if (!ValidateIndex(this._index))
                throw new Exception("Invalid Operation!");

            return this._list[this._index];
        }
    }
}
