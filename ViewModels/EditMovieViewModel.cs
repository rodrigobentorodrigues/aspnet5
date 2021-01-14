using Course.Models;
using System.Web.Mvc;

namespace Course.ViewModels
{
    public class EditMovieViewModel
    {

        public Movie Movie { get; set; }
        public SelectList Genres { get; set; }

    }
}