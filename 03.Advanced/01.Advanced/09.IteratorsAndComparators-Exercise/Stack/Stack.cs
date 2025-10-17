using System.Collections;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _arr;
        public int Count { get; private set; }

        public Stack()
        {
            _arr = new T[4];
        }

        public void Push(T element)
        {
            if (this.Count == this._arr.Length)
                Grow();

            this._arr[this.Count++] = element;
        }

        private void Grow()
        {
            T[] newArr = new T[this.Count * 2];

            Array.Copy(this._arr, newArr, this.Count);
            this._arr = newArr;
        }

        public T Pop()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("No elements");

            T element = this._arr[--this.Count];
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = this.Count; i >= 0; i--)
            //    yield return this._arr[i];
            return new StackEnumerator(this._arr, this.Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        private class StackEnumerator : IEnumerator<T>
        {
            private readonly T[] _arr;
            private readonly int _count;

            private int _index;

            public T Current => this._arr[this._index];

            object IEnumerator.Current => this.Current;

            public StackEnumerator(T[] arr, int count)
            {
                this._arr = arr;
                this._count = count;

                Reset();
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                this._index--;

                if (this._index < 0)
                    return false;

                return true;
            }

            public void Reset()
            {
                this._index = this._count;
            }
        }
    }
}
