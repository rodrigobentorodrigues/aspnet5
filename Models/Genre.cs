﻿using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class Genre
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}