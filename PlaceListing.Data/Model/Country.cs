namespace PlaceListing.API.Data.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string NatCode { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}