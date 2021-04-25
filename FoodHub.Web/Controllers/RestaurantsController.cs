using FoodHub.Data.Models;
using FoodHub.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound");
            }

            else
            {
                return View(model);
            }

            
        }

        //represent form to the user
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //hit when user click submit btn in from
        [HttpPost]
        [ValidateAntiForgeryToken]    //use to prevent cross-site scripting attacks (as wll as view, see @Html.AntiForgeryToken() in create view)
        public ActionResult Create(Restaurant restaurant)
        {
            //instead using this we use data annotations
            //if(String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}

            if(ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
           
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);

            if(model == null)
            {
                return HttpNotFound();

            } else
            {
                return View(model);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}