using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceListing.API.Data.Model;

namespace PlaceListing.API.Data.DbConfigurations
{
    public class CountryDbConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Singapore",
                    NatCode = "SGP"
                },
                new Country
                {
                    Id = 2,
                    Name = "New York",
                    NatCode = "USA"
                }, new Country
                {
                    Id = 3,
                    Name = "South Korea",
                    NatCode = "KOR"
                }
            );
        }
    }
}
