using FoodHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHub.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodHubDbContext db;

        public SqlRestaurantData(FoodHubDbContext db)
        {
            this.db = db;
        }

        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(r => r.Name);

            //Or
            //return from r in db.Restaurants
            //       orderby r.Name
            //       select r;
        }

        public void Update(Restaurant restaurant)
        {
            //1st method (without multiple users)
            //var r = Get(restaurant.Id);
            //r.Name = restaurant.Name;
            //r.Cuisine = restaurant.Cuisine;
            //db.SaveChanges();

            //2nd method
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
