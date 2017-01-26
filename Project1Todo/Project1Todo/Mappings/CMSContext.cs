using Project1Todo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1Todo.Mappings
{
    public class CMSContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<Item> Item { get; set; }

        public CMSContext() 
            : base("Project1Todo")
        {

        }

        public static CMSContext Create()
        {
            return new CMSContext();
        }
    }
}