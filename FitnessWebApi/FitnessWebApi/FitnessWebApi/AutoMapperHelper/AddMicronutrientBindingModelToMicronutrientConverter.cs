namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;

    public class AddMicronutrientBindingModelToMicronutrientConverter : ITypeConverter<AddNutrientBindingModel, Micronutrient>
    {
        public Micronutrient Convert(AddNutrientBindingModel source, Micronutrient destination, ResolutionContext context)
        {
            TypeOfMicronutrients nutrientType = (TypeOfMicronutrients)Enum.Parse(typeof(TypeOfMicronutrients), source.Type);

            destination = new Micronutrient()
            {
                Name = source.Name,
                Type = nutrientType,
                Quantity = source.Quantity
            };

            return destination;
        }
    }
}