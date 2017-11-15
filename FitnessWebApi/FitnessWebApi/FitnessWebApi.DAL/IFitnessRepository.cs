namespace FitnessWebApi.DAL
{
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public interface IFitnessRepository
    {
        IEnumerable<Food> Foods();

        Food FoodById(int id);

        void AddFood(Food food);

        void UpdateFood(Food food);

        void DeleteFood(int id);
    }
}
