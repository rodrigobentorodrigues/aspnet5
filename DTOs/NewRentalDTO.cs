using System.Collections.Generic;

namespace Course.DTOs
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MoviesId { get; set; }
    }
}