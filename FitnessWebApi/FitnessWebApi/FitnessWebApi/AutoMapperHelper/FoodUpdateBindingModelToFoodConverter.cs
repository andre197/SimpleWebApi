namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;

    public class FoodUpdateBindingModelToFoodConverter : ITypeConverter<UpdateFoodBindingModel, Food>
    {
        public Food Convert(UpdateFoodBindingModel source, Food destination, ResolutionContext context)
        {
            Category category = (Category)Enum.Parse(typeof(Category), source.Category);
            TypesOfFat fats = (TypesOfFat)Enum.Parse(typeof(TypesOfFat), source.Fats);

            destination = new Food()
            {
                Id = source.Id,
                Name = source.Name,
                Category = category,
                ProteinContent = source.ProteinContent,
                SugarContent = source.SugarContent,
                Fats = fats,
                FatsContent = source.FatsContent
            };

            return destination;
        }
    }
}