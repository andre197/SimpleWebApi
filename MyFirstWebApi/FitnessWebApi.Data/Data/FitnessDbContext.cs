namespace FitnessWebApi.DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class FitnessDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer($@"Server=DESKTOP-7KJQ34E;Database=FitnessApiDb;Integrated Security=True");
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();

            var items = new Dictionary<object, object>();

            foreach (var entry in this.ChangeTracker
                                        .Entries()
                                        .Where(e => (e.State == EntityState.Added) 
                                                    || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;

                var context = new ValidationContext(entity, serviceProvider, items);

                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
