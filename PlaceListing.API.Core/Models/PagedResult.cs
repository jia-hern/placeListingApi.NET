namespace PlaceListing.API.Core.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSizeLimit { get; set; }
        public List<T> Items { get; set; }
    }
}
