using Course.DTOs;
using Course.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Course.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }


        [HttpPost]
        public IHttpActionResult CreateNew(NewRentalDTO newRental)
        {
            //if (newRental.MoviesId.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.SingleOrDefault((c) => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("Invalid Customer ID.");

            var movies = _context.Movies.Where((m) => newRental.MoviesId.Contains(m.Id)).ToList();

            //if (movies.Count != newRental.MoviesId.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
                
            }

            _context.SaveChanges();
            
            return Ok();
        }

    }
}
