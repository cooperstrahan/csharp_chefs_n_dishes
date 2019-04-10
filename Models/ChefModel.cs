using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class OldEnoughAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime)value >= DateTime.Today.AddYears(-18))
            {
                return new ValidationResult("The Chef must be at least 18 years old.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [MinLength(2)]
        public string ChefName { get; set; }

        [Required]
        [OldEnough]
        public DateTime DateOfBirth { get; set; }
        
        public List<Dish> Dishes { get; set; } = new List<Dish>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}