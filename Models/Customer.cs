using System;
using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth:")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type:")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}