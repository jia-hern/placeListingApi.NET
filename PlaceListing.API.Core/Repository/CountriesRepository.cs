using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlaceListing.API.Core.Exceptions;
using PlaceListing.API.Core.Interfaces;
using PlaceListing.API.Core.Models.Country;
using PlaceListing.API.Data;
using PlaceListing.API.Data.Model;

namespace PlaceListing.API.Core.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly PlaceListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(PlaceListingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CountryDto> GetCountryDetailsOfPlace(int id)
        {
            var country = await _context.Countries.Include(q => q.Places)
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);
            if(country is null)
            {
                throw new NotFoundException(nameof(GetCountryDetailsOfPlace), id);
            }
            return country;
        }
    }
}
