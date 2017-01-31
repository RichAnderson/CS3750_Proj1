using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1ToDo.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string categoryName { get; set; }
        public DateTime creationDate { get; set; }
        public bool deleted { get; set; }

        public ICollection<Categorization> Categorizations { get; set; }
    }
}
