namespace FitnessWebApi.DAL
{
    using Data;
    using Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class FitnessRepository : IFitnessRepository
    {
        private FitnessDbContext db;

        public FitnessRepository(FitnessDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Food> Foods()
        {
            using (db)
            {
                List<Food> foods = this.db.Foods.ToList();

                return foods;
            }
        }

        public Food FoodById(int id)
        {
            using (this.db)
            {
                Food food = this.db.Foods.FirstOrDefault(f => f.Id == id);

                return food;
            }
        }

        public void AddFood(Food food)
        {
            using (this.db)
            {
                //try
                //{
                    this.db.Foods.Add(food);
                    this.db.SaveChanges();
                //}
                //catch (ValidationException)
                //{
                //    throw new DataException("Unable to save changes!");
                //}
                //catch
                //{
                //    throw new DataException("Unable to add food!");
                //}
            }
        }

        public void DeleteFood(int id)
        {
            using (this.db)
            {
                try
                {
                    Food food = this.db.Foods.FirstOrDefault(f => f.Id == id);

                    this.db.Foods.Remove(food);
                    this.db.SaveChanges();
                }
                catch (ValidationException)
                {
                    throw new DataException("Unable to save changes!");
                }
                catch
                {
                    throw new DataException("Unable to remove food!");
                }
            }
        }

        public void UpdateFood(Food food)
        {
            using (this.db)
            {
                //try
                //{
                    Food toBeUpdated = this.db.Foods.FirstOrDefault(f => f.Id == food.Id);
                    this.db.Foods.Remove(toBeUpdated);

                    toBeUpdated = food;

                    this.db.Foods.Add(toBeUpdated);
                    this.db.SaveChanges();
                //}
                //catch (ValidationException)
                //{
                //    throw new DataException("Unable to save changes!");
                //}
                //catch
                //{
                //    throw new DataException("Unable to add food!");
                //}
            }
        }
    }
}
