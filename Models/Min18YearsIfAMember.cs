using System;
using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthday is required");

            int age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age > 18) ? ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to Membership Type");
        }

    }
}