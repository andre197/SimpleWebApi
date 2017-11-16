namespace FitnessWebApi.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNutrientBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
        
        public decimal Quantity { get; set; }
    }
}