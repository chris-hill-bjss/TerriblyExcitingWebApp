using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TerriblyExcitingWebApp.Data
{
    public class TerriblyExcitingDbContextFactory : IDesignTimeDbContextFactory<TerriblyExcitingDbContext>
    {
        public TerriblyExcitingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TerriblyExcitingDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1432;Database=AssessmentDb;User=SA;password=Abc123Abc123");

            return new TerriblyExcitingDbContext(optionsBuilder.Options);
        }
    }
}
