using SBLPIMIDTP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBLPIMIDTP.Repositories
{
    public class ItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTime.Now },
            new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTime.Now },
            new Item() { Id = Guid.NewGuid(), Name = "Bronze Sheild", Price = 18, CreatedDate = DateTime.Now }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItemById(Guid id)
        {
            return items.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
