﻿namespace FitnessWebApi.DAL
{
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Dynamic;

    public class MicronutrientsRepository : IFitnessRepository<Micronutrient>
    {
        private FitnessDbContext db;

        public MicronutrientsRepository()
        {
            this.db = new FitnessDbContext();
        }

        public IEnumerable<Micronutrient> GetAll(string orderBy)
        {
            using (this.db)
            {
                List<Micronutrient> micronutrients = this.db.Micronutrients
                    .OrderBy(orderBy)
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
                    .SingleOrDefault();

                return micronutrient;
            }
        }

        public IEnumerable<Micronutrient> GetAllContaining(string name, string orderBy)
        {
            using (this.db)
            {
                List<Micronutrient> result = this.db
                    .Micronutrients
                    .Where(f => f.Name
                        .Contains(name))
                    .OrderBy(orderBy)
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
                    throw new DataException("Unable to add micronutrient!");
                }
            }
        }

        public void DeleteEntity(int id)
        {
            using (this.db)
            {
                try
                {
                    Micronutrient micronutrient = this.db.Micronutrients.SingleOrDefault(f => f.Id == id);

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

                    newMicronutrient.Foods = micronutrient.Foods;

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
                            .SingleOrDefault(f => f.Id == foodId);

                this.db.Micronutrients
                    .SingleOrDefault(m => m.Id == micronutrientId)
                    .Foods
                    .Add(new FoodsMicronutrients() { FoodId = food.Id });

                this.db.SaveChanges();
            }
        }
    }
}
