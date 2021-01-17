using AutoMapper;
using Course.Data;
using Course.DTOs;
using Course.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Course.Controllers.Api
{
    public class MoviesController : ApiController
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

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault((mov) => mov.Id == id);

            if (movie == null)
                return NotFound();

            var movieDTO = Mapper.Map<Movie, MovieDTO>(movie);
            return Ok(movieDTO);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault((mov) => mov.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDTO, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault((mov) => mov.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }

    }
}
