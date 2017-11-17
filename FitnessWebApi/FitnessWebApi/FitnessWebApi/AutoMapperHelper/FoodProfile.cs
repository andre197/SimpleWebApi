namespace FitnessWebApi.AutoMapperHelper
{
    using AutoMapper;
    using BindingModels;
    using DAL.Data.Models;
    using DAL.Data.Models.Enumerations;
    using System;
    using ViewModels;

    public class FoodProfile : Profile
    {
        private const int ProteinMultiplier = 4;
        private const int FatsMultiplier = 9;
        private const decimal SugarMultiplier = 3.867m;

        public FoodProfile()
        {
            CreateMap<AddFoodBindingModel, Food>()
                .ForMember(dest => dest.Fats, 
                            src => src.MapFrom(af => (TypesOfFat)Enum.Parse(typeof(TypesOfFat), af.Fats)))
                .ForMember(dest=>dest.Category,
                            src => src.MapFrom(af => (Category)Enum.Parse(typeof(Category), af.Category)));

            CreateMap<UpdateFoodBindingModel, Food>()
                .ForMember(dest => dest.Fats,
                            src => src.MapFrom(uf => (TypesOfFat)Enum.Parse(typeof(TypesOfFat), uf.Fats)))
                .ForMember(dest => dest.Category,
                            src => src.MapFrom(uf => (Category)Enum.Parse(typeof(Category), uf.Category)));
        }
    }
}