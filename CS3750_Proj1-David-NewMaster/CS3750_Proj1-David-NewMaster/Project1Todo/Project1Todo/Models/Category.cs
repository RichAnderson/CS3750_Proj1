using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1Todo.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        //public virtual ApplicationUser User { get; set; }

    }
}