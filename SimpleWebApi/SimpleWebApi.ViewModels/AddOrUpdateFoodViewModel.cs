namespace SimpleWebApi.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddOrUpdateFoodViewModel
    {
        [Required]
        [Range(3, 30)]
        public string Name { get; set; }

        [Required]
        public double ProteinContent { get; set; }

        [Required]
        public double SugarContent { get; set; }

        [Required]
        public string TypeOfFats { get; set; }

        [Required]
        public double FatsContent { get; set; }
    }
}
