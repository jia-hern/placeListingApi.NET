using PlaceListing.API.Core.Models.Country;
using PlaceListing.API.Data.Model;

namespace PlaceListing.API.Core.Interfaces
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<CountryDto> GetCountryDetailsOfPlace(int id);
    }
}
