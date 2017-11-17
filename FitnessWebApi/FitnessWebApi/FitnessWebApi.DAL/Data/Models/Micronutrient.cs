﻿namespace FitnessWebApi.DAL.Data.Models
{
    using Enumerations;
    using FitnessWebApi.DAL.Data.Models.Validation;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Micronutrient
    {
        [Key]
        public int Id { get; set; }

        public TypeOfMicronutrients Type { get; set; }

        [Required(ErrorMessage = "The name cannot be null")]
        [Range(3,20, ErrorMessage = "The entered name is shorter than 3 symbols or longer than 20!")]
        public string Name { get; set; }

        [BiggerThanZero(ErrorMessage = "Quantity cannot be lower than or equal to 0!")]
        public decimal Quantity { get; set; }

        public virtual ICollection<FoodsMicronutrients> Foods { get; set; } = new HashSet<FoodsMicronutrients>();
    }
}
