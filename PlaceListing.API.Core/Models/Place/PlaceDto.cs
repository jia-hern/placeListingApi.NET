namespace PlaceListing.API.Core.Models.Place
{
    public class PlaceDto: BasePlaceDto, IBaseIdDto
    {
        public int Id { get; set; }
    }
}
