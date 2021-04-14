using FoodHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodHub.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Food Hub - Colombo 6", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Food Hub - Colombo 4", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Food Hub - Colombo 11", Cuisine = CuisineType.None},
                new Restaurant {Id = 4, Name = "Food Hub - Colombo 10", Cuisine = CuisineType.Indian}
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id); //First or Default return selected value or can not find that value then (default value) null in this case
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
