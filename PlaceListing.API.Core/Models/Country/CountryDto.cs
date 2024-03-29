using PlaceListing.API.Core.Models.Place;

namespace PlaceListing.API.Core.Models.Country
{
    public class CountryDto : BaseCountryDto, IBaseIdDto
    {
        public int Id { get; set; }
        public List<PlaceDto> Places { get; set; }
    }
}
