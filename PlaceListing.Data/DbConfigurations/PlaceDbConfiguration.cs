using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceListing.API.Data.Model;

namespace PlaceListing.API.Data.DbConfigurations
{
    public class PlaceDbConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasData(
                new Place
                {
                    Id = 1,
                    Name = "Resorts World Sentosa",
                    Address = "8 Sentosa Gateway, 098269",
                    Rating = 5,
                    CountryId = 1
                },
                new Place
                {
                Id = 2,
                    Name = " Moxy NYC Times Square",
                    Address = "485 7th Ave, New York, NY 10018, United States",
                    Rating = 5,
                    CountryId = 2
                },
                new Place
                {
                    Id = 3,
                    Name = " LOTTE HOTEL BUSAN",
                    Address = "772 Gaya-daero, Busanjin-gu, Busan, South Korea",
                    Rating = 5,
                    CountryId = 3
                }
            );
        }
    }
}
