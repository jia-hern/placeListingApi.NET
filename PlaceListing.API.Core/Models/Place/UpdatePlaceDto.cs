namespace PlaceListing.API.Core.Models.Place
{
    public class UpdatePlaceDto : BasePlaceDto, IBaseIdDto
    {
        public int Id { get; set; }
    }
}
