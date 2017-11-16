namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;

    public class UpdateMicronutrientBindingModelToMicronutrientConverter : ITypeConverter<UpdateMicronutrientBindingModel, Micronutrient>
    {
        public Micronutrient Convert(UpdateMicronutrientBindingModel source, Micronutrient destination, ResolutionContext context)
        {
            TypeOfMicronutrients nutrientType = (TypeOfMicronutrients)Enum.Parse(typeof(TypeOfMicronutrients), source.Type);

            destination = new Micronutrient()
            {
                Id = source.Id,
                Name = source.Name,
                Type = nutrientType,
                Foods = source.Foods,
                Quantity = source.Quantity
            };

            return destination;
        }
    }
}