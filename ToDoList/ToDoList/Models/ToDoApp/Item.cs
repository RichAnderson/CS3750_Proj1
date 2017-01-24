using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.ToDoApp
{
    public class Item
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public int listID { get; set; }
    }
}