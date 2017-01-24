using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Todo.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string item { get; set; }
        public bool complete { get; set; }
        public DateTime completionDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
