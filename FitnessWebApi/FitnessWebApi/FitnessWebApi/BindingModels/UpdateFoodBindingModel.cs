namespace FitnessWebApi.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateFoodBindingModel
    {
        [Required]
        public int Id { get; set; }

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