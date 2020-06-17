using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Video.Models;

namespace Video.Controllers
{
    public class MoviesController : Controller
    {
        private AppDbContext dbContext;

        public MoviesController(AppDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            var movies = dbContext.Movies.ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
}
