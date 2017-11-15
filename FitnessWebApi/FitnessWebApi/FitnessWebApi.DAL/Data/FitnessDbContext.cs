namespace FitnessWebApi.DAL.Data
{
    using Models;
    using System.Data.Entity;

    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext()
            : base(@"name=FitnessDb")
        {
           // Database.SetInitializer(new DropCreateDatabaseAlways<FitnessDbContext>());
        }

        public DbSet<Food> Foods { get; set; }    
    }
}
