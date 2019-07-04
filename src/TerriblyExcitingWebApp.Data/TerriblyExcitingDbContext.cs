using Microsoft.EntityFrameworkCore;
using TerriblyExcitingWebApp.Data.Models;

namespace TerriblyExcitingWebApp.Data
{
    public class TerriblyExcitingDbContext : DbContext
    {
        public TerriblyExcitingDbContext(DbContextOptions<TerriblyExcitingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Forecast> Forecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TerriblyExcitingDb;Trusted_Connection=True;");
        }
    }
}
