using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            // 1. Read first line: strings to add
            string[] itemsToAdd = reader.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // 2. Read second line: number of remove operations
            int removeOperations = int.Parse(reader.ReadLine());

            // 3. Initialize collections
            IAddable addCollection = new AddCollection();
            IAddable addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            // 4. Add items and collect indexes
            List<int> addCollectionIndexes = new List<int>();
            List<int> addRemoveCollectionIndexes = new List<int>();
            List<int> myListIndexes = new List<int>();

            foreach (var item in itemsToAdd)
            {
                addCollectionIndexes.Add(addCollection.Add(item));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(item));
                myListIndexes.Add(myList.Add(item));
            }

            // 5. Write Add operation results
            writer.WriteLine(string.Join(" ", addCollectionIndexes));
            writer.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            writer.WriteLine(string.Join(" ", myListIndexes));

            // 6. Remove items for collections that support removal
            IRemovable removableAddRemove = (IRemovable)addRemoveCollection;
            IRemovable removableMyList = myList;

            List<string> removedFromAddRemove = new List<string>();
            List<string> removedFromMyList = new List<string>();

            for (int i = 0; i < removeOperations; i++)
            {
                removedFromAddRemove.Add(removableAddRemove.Remove());
                removedFromMyList.Add(removableMyList.Remove());
            }

            // 7. Write Remove operation results
            writer.WriteLine(string.Join(" ", removedFromAddRemove));
            writer.WriteLine(string.Join(" ", removedFromMyList));
        }
    }
}
