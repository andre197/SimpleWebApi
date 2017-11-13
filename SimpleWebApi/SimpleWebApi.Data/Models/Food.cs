namespace SimpleWebApi.Data.Models
{
    using Enumerations;

    public class Food
    {
        public int Id { get; set; } 

        public string  Name { get; set; }

        public double ProteinContent { get; set; }

        public double SugarContent { get; set; }

        public TypesOfFat Fats { get; set; }

        public double FatsContent { get; set; }
    }
}
