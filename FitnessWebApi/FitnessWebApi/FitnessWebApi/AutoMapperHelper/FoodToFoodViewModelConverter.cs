﻿namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using DAL.Data.Models;
    using ViewModels;

    internal class FoodToFoodViewModelConverter : ITypeConverter<Food, FoodViewModel>
    {
        private const int ProteinMultiplier = 4;
        private const int FatsMultiplier = 9;
        private const decimal SugarMultiplier = 3.867m;

        public FoodViewModel Convert(Food source, FoodViewModel destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            decimal caloriesPerProtein = source.ProteinContent * ProteinMultiplier;
            decimal caloriesPerFat = source.FatsContent * FatsMultiplier;
            decimal caloriesPerSugar = source.SugarContent * SugarMultiplier;

            destination = new FoodViewModel(source.Id,
                        source.Name,
                        source.Category.ToString(),
                        caloriesPerProtein,
                        caloriesPerSugar,
                        caloriesPerFat,
                        source.Fats.ToString(),
                        source.Count);

            return destination;
        }
    }
}