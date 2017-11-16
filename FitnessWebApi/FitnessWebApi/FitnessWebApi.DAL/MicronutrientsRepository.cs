namespace FitnessWebApi.DAL
{
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MicronutrientsRepository : IFitnessRepository<Micronutrient>
    {
        private FitnessDbContext db;

        public MicronutrientsRepository(FitnessDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Micronutrient> GetAll()
        {
            using (this.db)
            {
                List<Micronutrient> micronutrients = this.db.Micronutrients
                    .Include(m => m.Foods)
                    .ToList();

                return micronutrients;
            }
        }

        public Micronutrient GetById(int id)
        {
            using (this.db)
            {
                Micronutrient micronutrient = this.db.Micronutrients
                    .Where(m => m.Id == id)
                    .Include(m => m.Foods)
                    .FirstOrDefault();

                return micronutrient;
            }
        }

        public IEnumerable<Micronutrient> GetAllContaining(string name)
        {
            using (this.db)
            {
                List<Micronutrient> result = this.db
                    .Micronutrients
                    .Where(f => f.Name
                        .Contains(name))
                    .Include(m => m.Foods)
                    .ToList();

                return result;
            }
        }

        public void AddEntity(Micronutrient micronutrient)
        {
            using (this.db)
            {
                try
                {
                    this.db.Micronutrients.Add(micronutrient);
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
                    Micronutrient micronutrient = this.db.Micronutrients.FirstOrDefault(f => f.Id == id);

                    this.db.Micronutrients.Remove(micronutrient);
                    this.db.SaveChanges();
                }
                catch
                {
                    throw new DataException("Unable to remove food!");
                }
            }
        }

        public void UpdateEntity(int id, Micronutrient newMicronutrient)
        {
            using (this.db)
            {
                try
                {
                    Micronutrient micronutrient = this.db.Micronutrients.FirstOrDefault(f => f.Id == id);

                    if (micronutrient == null)
                    {
                        throw new InvalidOperationException();
                    }

                    this.db.Micronutrients.Remove(micronutrient);
                    this.db.Micronutrients.Add(newMicronutrient);
                    this.db.SaveChanges();
                }
                catch
                {
                    throw new DataException("Unable to add food!");
                }
            }
        }

        public void AddConnection(int micronutrientId, int foodId)
        {
            using (this.db)
            {
                Food food = this.db.Foods
                            .FirstOrDefault(f => f.Id == foodId);

                this.db.Micronutrients
                    .FirstOrDefault(m => m.Id == micronutrientId)
                    .Foods
                    .Add(food);

                this.db.SaveChanges();
            }
        }
    }
}
