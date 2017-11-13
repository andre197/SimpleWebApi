namespace SimpleWebApi.Services.AutoMapperHelper
{
    using AutoMapper;
    using Models;
    using ViewModels;

    public class FoodToFoodViewModelConverter : ITypeConverter<Food, FoodViewModel>
    {
        private const int ProteinMultiplier = 4;
        private const int FatsMultiplier = 9;
        private const double SugarMultiplier = 3.867;

        public FoodViewModel Convert(Food source, FoodViewModel destination, ResolutionContext context)
        {
            double caloriesPerProtein = source.ProteinContent * ProteinMultiplier;
            double caloriesPerFat = source.FatsContent * FatsMultiplier;
            double caloriesPerSugar = source.SugarContent * SugarMultiplier;

            destination = new FoodViewModel(source.Id, 
                        source.Name, 
                        caloriesPerProtein, 
                        caloriesPerSugar, 
                        caloriesPerFat, 
                        source.Fats.ToString());

            return destination;
        }
    }
}
