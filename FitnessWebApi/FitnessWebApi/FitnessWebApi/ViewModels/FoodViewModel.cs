namespace FitnessWebApi.ViewModels
{
    public class FoodViewModel
    {
        public FoodViewModel(int id,
                string name,
                string category,
                decimal proteintContentCalories,
                decimal sugarContentCalories,
                decimal fatContentCalories,
                string fatType,
                int totalNutrientsCount)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.ProteinContentCalories = proteintContentCalories;
            this.SugarContentCalories = sugarContentCalories;
            this.FatContentCalories = fatContentCalories;
            this.FatType = fatType;
            this.TotalNutrientsCount = totalNutrientsCount;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Category { get; set; }

        public decimal ProteinContentCalories { get; private set; }

        public decimal SugarContentCalories { get; private set; }

        public decimal FatContentCalories { get; private set; }

        public string FatType { get; private set; }

        public decimal TotalCallories
            => this.ProteinContentCalories
            + this.SugarContentCalories
            + this.FatContentCalories;

        public int TotalNutrientsCount { get; set; }
    }
}