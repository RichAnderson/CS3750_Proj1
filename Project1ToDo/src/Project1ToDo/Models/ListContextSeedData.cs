using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1ToDo.Models
{
    public class ListContextSeedData
    {
        private ListContext _context;

        public ListContextSeedData(ListContext context)
        {
            _context = context;
        }

        public async Task SeeData()
        {
            if (!_context.Lists.Any())
            {
                var newList = new List()
                {
                    dateCreated = DateTime.Now,
                    listName = "Test List 1",
                    Items = new List<Item>()
                    {
                        new Item {itemName = "first thing first", order = 1, dateCreated = DateTime.Now },
                        new Item {itemName = "second thing second", order = 2, dateCreated = DateTime.Now },
                        new Item {itemName = "third thing third", order = 3, dateCreated = DateTime.Now },
                        new Item {itemName = "forth thing forth", order = 4, dateCreated = DateTime.Now }
                    }
                };

                _context.Lists.Add(newList);
                _context.Items.AddRange(newList.Items);

                var secList = new List()
                {
                    dateCreated = DateTime.Now,
                    listName = "Test List 2",
                    Items = new List<Item>()
                    {
                        new Item {itemName = "first thing first", order = 1, dateCreated = DateTime.Now },
                        new Item {itemName = "second thing second", order = 2, dateCreated = DateTime.Now },
                        new Item {itemName = "third thing third", order = 3, dateCreated = DateTime.Now },
                        new Item {itemName = "forth thing forth", order = 4, dateCreated = DateTime.Now }
                    }
                };

                _context.Lists.Add(secList);
                _context.Items.AddRange(secList.Items);
            }
        }
    }
}
