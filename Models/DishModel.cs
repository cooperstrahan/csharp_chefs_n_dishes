using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [MinLength(2)]
        public string DishName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Calories must be 1 or greater")]
        public int Calories { get; set; }

        [Required]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        [Range(1,5, ErrorMessage="Tastiness must be within the range 1 - 5")]
        public int Tastiness { get; set; }

        [Required]
        public int ChefId { get; set; }
        public Chef Chef { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public List<Chef> Chefs { get; set; }
        public Dish() { }
        public Dish(List<Chef> chefs)
        {
            Chefs = chefs;
        }
    }
}