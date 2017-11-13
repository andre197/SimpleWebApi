namespace SimpleWebApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FitnessApiDbContext : DbContext
    {
        private string dbName;

        public FitnessApiDbContext(string dbName)
        {
            this.dbName = dbName;
        }

        public FitnessApiDbContext() 
            : this("FitnessApiDb")
        { }

        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer($@"Server=DESKTOP-7KJQ34E;Database={this.dbName};Integrated Security=True");
        }
    }
}
