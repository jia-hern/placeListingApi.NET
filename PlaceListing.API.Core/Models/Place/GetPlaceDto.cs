namespace PlaceListing.API.Core.Models.Place
{
    public class GetPlaceDto: BasePlaceDto, IBaseIdDto
    {
        public int Id { get; set; }
    }
}
