using AutoMapper;
using PlaceListing.API.Data.Model;
using PlaceListing.API.Core.Models.Country;
using PlaceListing.API.Core.Models.Place;
using PlaceListing.API.Core.Models.Users;

namespace PlaceListing.API.Core.MapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig() {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Place, PlaceDto>().ReverseMap();
            CreateMap<Place, GetPlaceDto>().ReverseMap();
            CreateMap<Place, CreatePlaceDto>().ReverseMap();
            CreateMap<Place, UpdatePlaceDto>().ReverseMap();

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}
