using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models
{
    public class AddCollection : IAddable
    {
        private const int MaxCapacity = 100;
        private List<string> items;

        public AddCollection()
        {
            items = new List<string>(MaxCapacity);
        }

        public int Add(string item)
        {
            if (items.Count >= MaxCapacity)
                throw new InvalidOperationException("Collection is full.");

            items.Add(item);
            return items.Count - 1;
        }
    }
}
