namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class MicronutrientToMicronutrientViewModelConverter : ITypeConverter<Micronutrient, MicronutrientViewModel>
    {
        public MicronutrientViewModel Convert(Micronutrient source, MicronutrientViewModel destination, ResolutionContext context)
        {
            string foods = string.Empty;

            if (source.Foods != null)
            {
                foods = string.Join(", ", source.Foods
                                            .Select(f => f.Name));
            }

            destination = new MicronutrientViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                Quantity = source.Quantity,
                Type = source.Type.ToString(),
                FoodsContainingIt = foods
            };

            return destination;
        }
    }
}