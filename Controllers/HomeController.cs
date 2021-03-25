using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoelHiltonsMovieCollectionEdit.Models;
using Microsoft.EntityFrameworkCore;
//this wonderful page is the home controller where all of the important stuff happens and is v important
namespace JoelHiltonsMovieCollectionEdit.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        //set context of the database here
        private MovieDBContext context { get; set; }

        public HomeController(MovieDBContext cxt)
        {
            context = cxt;
        }
        //return all the views
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }
        //get info from form
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        //post info from form
        [HttpPost]
        public IActionResult MovieForm(Movies movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return View("Confirmation", movie);
        }
        //get info from og form to display in the editable form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = context.Movies.Where(s => s.MovieID == id).FirstOrDefault();

            return View(movie);
        }
        //this is the delete action

        public IActionResult Delete(int id)
        {
            var movie = context.Movies.Where(s => s.MovieID == id).FirstOrDefault();
            //string confirm = "You deleted" + movie.Title;
            
            context.Movies.Remove(movie);
            context.SaveChanges();

            
            return RedirectToAction("MovieList");

        }


        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            var mov = context.Movies.Where(s => s.MovieID == movie.MovieID).FirstOrDefault();
            context.Movies.Remove(mov);
            context.Movies.Add(movie);
            context.SaveChanges();

            return RedirectToAction("MovieList", context.Movies);
        }



        public IActionResult MovieList(string confirm)
        {
            ViewBag.Confirmation = confirm;
            return View(context.Movies);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
