namespace FitnessWebApi.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddFoodBindingModel
    {
        [Required]
        [Range(3, 20)]
        public string Name { get; set; }
            
        [Required]
        public string Category { get; set; }

        public decimal ProteinContent { get; set; }
        
        public decimal SugarContent { get; set; }

        [Required]
        public string Fats { get; set; }
        
        public decimal FatsContent { get; set; }
    }
}