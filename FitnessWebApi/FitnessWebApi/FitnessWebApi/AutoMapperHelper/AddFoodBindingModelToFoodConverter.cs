namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;

    public class AddFoodBindingModelToFoodConverter : ITypeConverter<AddFoodBindingModel, Food>
    {
        public Food Convert(AddFoodBindingModel source, Food destination, ResolutionContext context)
        {
            var typeOfFats = (TypesOfFat)Enum.Parse(typeof(TypesOfFat), source.Fats);

            destination = new Food()
            {
                Name = source.Name,
                ProteinContent = source.ProteinContent,
                SugarContent = source.SugarContent,
                Fats = typeOfFats,
                FatsContent = source.FatsContent
            };

            return destination;
        }
    }
}