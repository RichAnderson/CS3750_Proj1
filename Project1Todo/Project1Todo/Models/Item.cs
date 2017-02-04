using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Todo.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool Complete { get; set; }
        public DateTime? CompletionDate { get; set; }

        //think i need to add this
        public virtual  int? ListId { get; set; }
    }
}
