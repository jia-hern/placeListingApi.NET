using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PlaceListing.API.Data.DbConfigurations;
using PlaceListing.API.Data.Model;

namespace PlaceListing.API.Data
{
    public class PlaceListingDbContext: IdentityDbContext<ApiUser>
    {
        public PlaceListingDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleDbConfiguration());
            modelBuilder.ApplyConfiguration(new CountryDbConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceDbConfiguration());
        }
    }

    public class PlaceListingDbContextFactory : IDesignTimeDbContextFactory<PlaceListingDbContext>
    {
        public PlaceListingDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PlaceListingDbContext>();
            var conn = config.GetConnectionString("PlaceListingDbConnectionString");
            optionsBuilder.UseSqlServer(conn);
            return new PlaceListingDbContext(optionsBuilder.Options);
        }
    }
}
