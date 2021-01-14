using Course.Data;
using Course.Models;
using Course.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Course.Controllers
{
    public class MoviesController : Controller
    {

        private readonly ApplicationContext _context;

        public MoviesController()
        {
            this._context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Movies
        [HttpGet]
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            return View(movie);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include((movie) => movie.Genre).ToList();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include((m) => m.Genre).SingleOrDefault((m) => m.Id == id);

            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = new SelectList(genres, "Id", "Name"),
                Movie = new Movie()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            movie.Genre = _context.Genres.Single((g) => g.Id == movie.GenreId);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault((m) => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var genres = _context.Genres.ToList();
            var viewModel = new EditMovieViewModel
            {
                Genres = new SelectList(genres, "Id", "Name"),
                Movie = movie
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault((m) => m.Id == movie.Id);

            if (movieInDb == null)
                return HttpNotFound();

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}