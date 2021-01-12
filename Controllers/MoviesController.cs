using Course.Data;
using Course.Models;
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

    }
}