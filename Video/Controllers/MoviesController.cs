﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Video.Models;
using Video.ViewModels;

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

        public ActionResult New()
        {
            var viewModel = new NewMovieFormViewModel
            {
                Movie = new Movie()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewMovieFormViewModel
                {
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0)
            {
                dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = dbContext.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberAvailable = movie.NumberAvailable;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return Content("Not found");

            var viewModel = new NewMovieFormViewModel
            {
                Movie = movie
            };

            return View("MovieForm", viewModel);
        }

        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return Content("Not Found");
            }

            dbContext.Remove(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}
