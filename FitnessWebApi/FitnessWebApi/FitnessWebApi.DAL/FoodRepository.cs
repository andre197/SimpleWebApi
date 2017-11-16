namespace FitnessWebApi.DAL
{
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class FoodRepository : IFitnessRepository<Food>
    {
        private FitnessDbContext db;

        public FoodRepository(FitnessDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Food> GetAll()
        {
            using (db)
            {
                List<Food> foods = this.db.Foods
                    .Include(f => f.Micronutrients)
                    .ToList();

                return foods;
            }
        }

        public Food GetById(int id)
        {
            using (this.db)
            {
                Food food = this.db.Foods
                    .Include(f => f.Micronutrients)
                    .SingleOrDefault(f => f.Id == id);

                return food;
            }
        }

        public IEnumerable<Food> GetAllContaining(string name)
        {
            using (this.db)
            {
                List<Food> result = this.db
                    .Foods
                    .Where(f => f.Name
                        .Contains(name))
                    .Include(f => f.Micronutrients)
                    .ToList();

                return result;
            }
        }

        public void AddEntity(Food food)
        {
            using (this.db)
            {
                try
                {
                    this.db.Foods.Add(food);
                    this.db.SaveChanges();
                }
                catch
                {
                    throw new DataException("Unable to add food!");
                }
            }
        }

        public void DeleteEntity(int id)
        {
            using (this.db)
            {
                try
                {
                    Food food = this.db.Foods.SingleOrDefault(f => f.Id == id);

                    this.db.Foods.Remove(food);
                    this.db.SaveChanges();
                }
                catch
                {
                    throw new DataException("Unable to remove food!");
                }
            }
        }

        public void UpdateEntity(int id, Food newFood)
        {
            using (this.db)
            {
                try
                {
                    Food food = this.db.Foods.SingleOrDefault(f => f.Id == id);

                    if (food == null)
                    {
                        throw new InvalidOperationException();
                    }

                    newFood.Micronutrients = food.Micronutrients;

                    this.db.Foods.Remove(food);
                    this.db.Foods.Add(newFood);
                    this.db.SaveChanges();
                }
                catch
                {
                    throw new DataException("Unable to add food!");
                }
            }
        }

        public void AddConnection(int foodId, int micronutrientId)
        {
            using (this.db)
            {
                Micronutrient micronutrient = this.db.Micronutrients
                            .SingleOrDefault(m => m.Id == micronutrientId);

                this.db.Foods
                    .SingleOrDefault(f => f.Id == foodId)
                    .Micronutrients
                    .Add(micronutrient);

                this.db.SaveChanges();
            }
        }
    }
}
