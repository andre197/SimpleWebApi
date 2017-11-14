namespace FitnessWebApi.DAL.Data.Models
{
    using Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(3,20)]
        public string Name { get; set; }
        
        [Range(0, double.MaxValue)]
        public double ProteinContent { get; set; }

        [Range(0, double.MaxValue)]
        public double SugarContent { get; set; }

        public TypesOfFat Fats { get; set; }

        [Range(0, double.MaxValue)]
        public double FatsContent { get; set; }
    }
}
