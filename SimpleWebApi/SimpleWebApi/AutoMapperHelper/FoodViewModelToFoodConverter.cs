namespace SimpleWebApi.AutoMapperHelper
{
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enumerations;
    using System;
    using ViewModels;

    internal class FoodViewModelToFoodConverter : ITypeConverter<FoodViewModel, Food>
    {
        private const double ProteinDevider = 4;
        private const double SugarDevider = 3.867;
        private const double FatsDevider = 9;

        public Food Convert(FoodViewModel source, Food destination, ResolutionContext context)
        {
            TypesOfFat typeOfFats = (TypesOfFat)Enum.Parse(typeof(TypesOfFat), source.FatType);

            destination = new Food()
            {
                Id = source.Id,
                Name = source.Name,
                ProteinContent = source.ProteinContentCalories / ProteinDevider,
                SugarContent = source.SugarContentCalories / SugarDevider,
                Fats = typeOfFats,
                FatsContent = source.FatContentCalories / FatsDevider
            };

            return destination;
        }
    }
}
