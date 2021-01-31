using System;
using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class Movie
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required(ErrorMessage = "The Genre field is required")]
        [Display(Name = "Genre:")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date:")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        
        [Range(1, 20)]
        [Display(Name = "Number in Stock:")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

    }
}