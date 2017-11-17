namespace FitnessWebApi.DAL.Data.Models
{
    using Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Validation;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredName)]
        [Range(3, 20, ErrorMessage = ErrorMessages.NameIsShorterLonger)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [BiggerThanZero(ErrorMessage = "Protein content cannot be lower than or equal to 0!")]
        public decimal ProteinContent { get; set; }

        [BiggerThanZero(ErrorMessage = "Sugar content cannot be lower than or equal to 0!")]
        public decimal SugarContent { get; set; }

        public TypesOfFat Fats { get; set; }

        [BiggerThanZero(ErrorMessage = "Fats content cannot be lower than or equal to 0!")]
        public decimal FatsContent { get; set; }

        [NotMapped]
        public int Count => this.Micronutrients.Count;

        public virtual ICollection<FoodsMicronutrients> Micronutrients { get; set; } = new HashSet<FoodsMicronutrients>();
    }
}
