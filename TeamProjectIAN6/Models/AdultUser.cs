using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Models
{
    public class AdultUser : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (ApplicationUser) validationContext.ObjectInstance;


            if (user.DateOfBirth == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Today.Year - user.DateOfBirth.Year;


            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("User must be an Adult");
        }
    }
}