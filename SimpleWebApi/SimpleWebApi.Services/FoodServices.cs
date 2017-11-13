namespace SimpleWebApi.Services
{
    using AutoMapper;
    using AutoMapperHelper;
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class FoodServices : IFoodServices
    {
        public List<FoodViewModel> ListFoods()
        {
            using (var db = new FitnessApiDbContext())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Food, FoodViewModel>()
                    .ConvertUsing<FoodToFoodViewModelConverter>());

                List<FoodViewModel> result = new List<FoodViewModel>();

                var foodsAdded = db.Foods;

                foreach (var food in foodsAdded)
                {
                    result.Add(Mapper.Map<Food, FoodViewModel>(food));
                }

                if (result.Count > 0)
                {
                    return result;
                }

                throw new NullReferenceException("No records were found in the current enitity");
            }
        }

        public FoodViewModel FindById(int id)
        {
            using (var db = new FitnessApiDbContext())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Food, FoodViewModel>()
                .ConvertUsing<FoodToFoodViewModelConverter>());

                Food food = db.Foods.FirstOrDefault(f => f.Id == id);

                if (food != null)
                {
                    FoodViewModel result = Mapper.Map<Food, FoodViewModel>(food);

                    return result;
                }

                throw new ArgumentNullException("The searched item was not found");
            }
        }
    }
}
