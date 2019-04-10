using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private DishAndChefContext dbContext;
        public HomeController(DishAndChefContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs
                .Include(chef => chef.Dishes)
                .ToList();

            return View(AllChefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("new")]
        public IActionResult Chef(Chef NewChef)
        {
            if(ModelState.IsValid)
            {
                dbContext.Chefs.Add(NewChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult ViewDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes
                .Include(dish => dish.Chef)
                .ToList();
            return View(AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            return View(new Dish(dbContext.Chefs.ToList()));
        }

        [HttpPost("dishes/new")]
        public IActionResult CreateDish(Dish NewDish)
        {
            System.Console.WriteLine(NewDish.DishName);
            System.Console.WriteLine(NewDish.Chef);

            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(NewDish);
                dbContext.SaveChanges();
                return RedirectToAction("ViewDishes");
            }
            else
            {
                return View("NewDish", getChefsWhenFailed());
            }
        }

        public Dish getChefsWhenFailed()
        {
            return new Dish()
            {
                Chefs = dbContext.Chefs.ToList()
            };
        }


    }
}
