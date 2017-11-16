namespace FitnessWebApi.BindingModels
{
    using DAL.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UpdateMicronutrientBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public List<Food> Foods { get; set; } = new List<Food>();
    }
}