
using Fashion_Friends_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion_Friends_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> products { get; set; }
    }
}
