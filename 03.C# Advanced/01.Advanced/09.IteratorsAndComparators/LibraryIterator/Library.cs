using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public Book Current => books[currentIndex];

            object IEnumerator.Current => this.Current;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                Reset();
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                currentIndex++;

                if (this.currentIndex >= books.Count)
                    return false;

                return true;
            }

            public void Reset()
            {
                currentIndex = -1;

            }
        }
    }
}
