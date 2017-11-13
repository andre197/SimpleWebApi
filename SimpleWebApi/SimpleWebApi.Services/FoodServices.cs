namespace SimpleWebApi.Services
{
    using AutoMapper;
    using AutoMapperHelper;
    using Contracts;
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class FoodServices : IFoodServices
    {
        public IEnumerable<FoodViewModel> ListFoods()
        {
            using (var db = new FitnessApiDbContext())
            {
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
                Food food = db.Foods.FirstOrDefault(f => f.Id == id);

                if (food != null)
                {
                    FoodViewModel result = Mapper.Map<Food, FoodViewModel>(food);

                    return result;
                }

                throw new ArgumentNullException("The searched item was not found");
            }
        }

        public void Insert(AddOrUpdateFoodViewModel food)
        {
            using (var db = new FitnessApiDbContext())
            {
                db.Foods.Add(Mapper.Map<AddOrUpdateFoodViewModel, Food>(food));

                db.SaveChanges();
            }
        }

        public void Delete(int foodId)
        {
            using (var db = new FitnessApiDbContext())
            {
                Food food = db.Foods.FirstOrDefault(f => f.Id == foodId);

                if (food != null)
                {
                    db.Foods.Remove(food);
                    db.SaveChanges();
                }

                throw new InvalidOperationException("No item with such id was found in the current entity");
            }
        }

        public void Update(FoodViewModel model)
        {
            using (var db = new FitnessApiDbContext())
            {
                try
                {
                    Food food = db.Foods.FirstOrDefault(f => f.Id == model.Id);

                    if (food != null)
                    {
                        food = Mapper.Map<FoodViewModel, Food>(model);

                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("model not found");
                }
            }
        }
    }
}
