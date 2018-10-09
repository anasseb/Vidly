using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
//using Vidly.ViewModel;

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

            return View(movie);
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}