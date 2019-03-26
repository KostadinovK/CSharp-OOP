using System;
using System.Linq;
using MuOnline.Models.Items;

namespace MuOnline.Models.Inventories
{
    using System.Collections.Generic;
    using Contracts;
    using Items.Contracts;

    public class Inventory : IInventory
    {
        private readonly List<IItem> items;

        public Inventory()
        {
            items = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
        
        public void AddItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            items.Add(item);
        }

        public bool RemoveItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            return items.Remove(item);
        }

        public IItem GetItem(string item)
        {
            var result = items.FirstOrDefault(i => i.GetType().Name == item);

            if (result == null)
            {
                throw new ArgumentException($"No item {item} exist!");
            }

            return result;
        }
    }
}
