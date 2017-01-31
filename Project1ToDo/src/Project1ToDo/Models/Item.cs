using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1ToDo.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string itemName { get; set; }
        public int order { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateCompleted { get; set; }
        public bool completed { get; set; }
        public bool deleted { get; set; }

    }
}
