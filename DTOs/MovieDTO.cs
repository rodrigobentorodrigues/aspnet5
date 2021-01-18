using System;
using System.ComponentModel.DataAnnotations;

namespace Course.DTOs
{
    public class MovieDTO
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

    }
}