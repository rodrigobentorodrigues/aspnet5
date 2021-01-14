using Course.Models;
using System.Web.Mvc;

namespace Course.ViewModels
{
    public class NewMovieViewModel
    {

        public Movie Movie { get; set; }
        public SelectList Genres { get; set; }

    }
}