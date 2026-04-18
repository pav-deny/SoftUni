using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        private List<string> items;
        private const int MaxCapacity = 100;

        public AddRemoveCollection()
        {
            items = new List<string>(MaxCapacity);
        }

        public int Add(string item)
        {
            if (items.Count >= MaxCapacity)
                throw new InvalidOperationException("Collection is full.");

            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removedItem = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return removedItem;
        }
    }
}
