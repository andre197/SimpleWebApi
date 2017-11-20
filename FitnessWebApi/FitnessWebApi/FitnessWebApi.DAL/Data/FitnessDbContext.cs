namespace FitnessWebApi.DAL.Data
{
    using Models;
    using System.Data.Entity;

    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext()
            : base(@"name=FitnessDb")
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FitnessDbContext>());
        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Micronutrient> Micronutrients { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<FoodsMicronutrients>()
                .HasKey(fm => new
                {
                    fm.FoodId,
                    fm.MicronutrientId
                });

            builder.Entity<FoodsMicronutrients>()
                .HasRequired(fm => fm.Food)
                .WithMany(f => f.Micronutrients)
                .HasForeignKey(fm => fm.FoodId)
                .WillCascadeOnDelete(false);

            builder.Entity<FoodsMicronutrients>()
                .HasRequired(fm => fm.Micronutrient)
                .WithMany(m => m.Foods)
                .HasForeignKey(fm => fm.MicronutrientId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(builder);
        }
    }
}
