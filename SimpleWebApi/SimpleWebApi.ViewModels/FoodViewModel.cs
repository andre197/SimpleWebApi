namespace SimpleWebApi.ViewModels
{
    public class FoodViewModel
    {
        public FoodViewModel(int id,
                string name,
                double proteintContentCalories,
                double sugarContentCalories,
                double fatContentCalories,
                string fatType)
        {
            this.Id = id;
            this.Name = name;
            this.ProteinContentCalories = proteintContentCalories;
            this.SugarContentCalories = sugarContentCalories;
            this.FatContentCalories = fatContentCalories;
            this.FatType = fatType;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public double ProteinContentCalories { get; private set; }

        public double SugarContentCalories { get; private set; }

        public double FatContentCalories { get; private set; }

        public string FatType { get; private set; }

        public double TotalCallories
            => this.ProteinContentCalories
            + this.SugarContentCalories
            + this.FatContentCalories;
    }
}
