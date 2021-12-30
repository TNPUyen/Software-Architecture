using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodSite.Models
{
    public class Food
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public String Status { get; set; }
    }
    public class FoodDBContext : DbContext
    {
        public DbSet<Food> Food { get; set; }
    }
}