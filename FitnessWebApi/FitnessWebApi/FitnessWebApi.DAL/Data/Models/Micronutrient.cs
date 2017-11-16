namespace FitnessWebApi.DAL.Data.Models
{
    using Enumerations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Micronutrient
    {
        [Key]
        public int Id { get; set; }

        public TypeOfMicronutrients Type { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public virtual ICollection<Food> Foods { get; set; } = new HashSet<Food>();
    }
}
