using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Movies/MoviesList")]
        public ActionResult MoviesList()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();

            return View(movie);
        }

        // GET: Movies/MovieDetails
        [Route("Movies/MovieDetails/{id}")]
        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Editmovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == id);

            if(movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("SaveMovie", viewModel);
        }

        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };

            return View("SaveMovie", viewModel);
        }

        public ActionResult SaveMovie(Movie movie)
        {
                if (movie.ID == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var MovieInDb = _context.Movies.First(c => c.ID == movie.ID);
                    MovieInDb.Name = movie.Name;
                    MovieInDb.Genre = movie.Genre;
                    MovieInDb.ReleaseDate = movie.ReleaseDate;
                    MovieInDb.NumberInStock = movie.NumberInStock;

                }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("MoviesList", "Movies");
        }
    }
}