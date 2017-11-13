namespace SimpleWebApi.AutoMapperHelper
{
    using AutoMapper;
    using Data.Models;
    using Data.Models.Enumerations;
    using System;
    using ViewModels;

    internal class AddOrUpdateFoodViewModelToFoodConverter : ITypeConverter<AddOrUpdateFoodViewModel, Food>
    {
        public Food Convert(AddOrUpdateFoodViewModel source, Food destination, ResolutionContext context)
        {
            var typeOfFats = (TypesOfFat)Enum.Parse(typeof(TypesOfFat), source.TypeOfFats);

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
