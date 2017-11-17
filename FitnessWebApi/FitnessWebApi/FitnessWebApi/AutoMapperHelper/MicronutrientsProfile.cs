namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;
    using System.Linq;
    using ViewModels;

    public class MicronutrientsProfile : Profile
    {
        public MicronutrientsProfile()
        {
            CreateMap<AddNutrientBindingModel, Micronutrient>()
                .ForMember(dest => dest.Type,
                            src => src.MapFrom(am => (TypeOfMicronutrients)Enum.Parse(typeof(TypeOfMicronutrients), am.Type)));

            CreateMap<UpdateMicronutrientBindingModel, Micronutrient>()
                .ForMember(dest => dest.Type,
                            src => src.MapFrom(um => (TypeOfMicronutrients)Enum.Parse(typeof(TypeOfMicronutrients), um.Type)));

            CreateMap<Micronutrient, MicronutrientViewModel>()
                .ForMember(dest => dest.FoodsContainingIt,
                            src => src.MapFrom(m => m.Foods != null ? string.Join(", ", m.Foods.Select(f => f.Name)) : string.Empty));
        }
    }
}