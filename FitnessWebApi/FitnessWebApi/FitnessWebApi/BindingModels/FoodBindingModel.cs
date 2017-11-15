namespace FitnessWebApi.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class FoodUpdateBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(3, 20)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double ProteinContent { get; set; }

        [Range(0, double.MaxValue)]
        public double SugarContent { get; set; }

        [Required]
        public string Fats { get; set; }

        [Range(0, double.MaxValue)]
        public double FatsContent { get; set; }
    }
}