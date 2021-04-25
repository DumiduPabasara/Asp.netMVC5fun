using FoodHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Data.Services
{
    public class FoodHubDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
