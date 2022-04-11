
using Fashion_Friends_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Friends_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> products { get; set; }
        public DbSet<UserRegister> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            ConfigureModelBuilderForUser(modelBuilder);
        }
        void ConfigureModelBuilderForUser(ModelBuilder model)
        {
            model.Entity<UserRegister>().ToTable("users");
        }
    }
}
