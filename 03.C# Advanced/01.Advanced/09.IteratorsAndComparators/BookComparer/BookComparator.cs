namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            int result = book1.Title.CompareTo(book2.Title);

            if (result == 0)
                result = book1.Year.CompareTo(book2.Year) * -1;

            return result;
        }
    }
}
