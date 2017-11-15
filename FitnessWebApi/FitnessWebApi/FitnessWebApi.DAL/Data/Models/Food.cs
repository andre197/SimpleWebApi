namespace FitnessWebApi.DAL.Data.Models
{
    using Enumerations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Food
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        private string name;
        [NotMapped]
        private decimal proteinContent;
        [NotMapped]
        private decimal sugarContent;
        [NotMapped]
        private decimal fatsContent;

        public string Name
        {
            get => this.name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public decimal ProteinContent
        {
            get => this.proteinContent;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.proteinContent = value;
            }
        }

        public decimal SugarContent
        {
            get => this.sugarContent;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.sugarContent = value;
            }
        }

        public TypesOfFat Fats { get; set; }

        public decimal FatsContent
        {
            get => this.fatsContent;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.fatsContent = value;
            }
        }
    }
}
