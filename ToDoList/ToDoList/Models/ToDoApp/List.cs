using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.ToDoApp
{
    public class List
    {
        public int listID { get; set; }
        public string listTitle { get; set; }

        public ICollection<Item> Items;
    }
}