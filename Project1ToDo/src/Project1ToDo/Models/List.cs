using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1ToDo.Models
{
    public class List
    {
        public int Id { get; set; }
        public string listName { get; set; }
        public DateTime dateCreated { get; set; }
        public bool deleted { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Categorization> Categorizations { get; set; }
    }
}
