﻿namespace FitnessWebApi.AutoMapperHelper
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
            TypesOfFat typeOfFats = (TypesOfFat)Enum.Parse(typeof(TypesOfFat), source.Fats);
            Category category = (Category)Enum.Parse(typeof(Category), source.Category);

            destination = new Food()
            {
                Name = source.Name,
                Category = category,
                ProteinContent = source.ProteinContent,
                SugarContent = source.SugarContent,
                Fats = typeOfFats,
                FatsContent = source.FatsContent
            };

            return destination;
        }
    }
}