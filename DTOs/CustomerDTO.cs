using Course.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Course.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please inform one name valid")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}