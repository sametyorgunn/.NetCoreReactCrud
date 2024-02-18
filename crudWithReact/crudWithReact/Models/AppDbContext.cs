using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace crudWithReact.Models
{
    public class AppDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Book>Books { get; set; }
    }
}
