using System.ComponentModel.DataAnnotations;

namespace PlaceListing.API.Core.Models.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }   
        public string NatCode { get; set; }
    }
}
