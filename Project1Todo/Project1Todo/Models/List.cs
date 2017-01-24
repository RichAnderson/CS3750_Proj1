﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Todo.Models
{
    public class List
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
