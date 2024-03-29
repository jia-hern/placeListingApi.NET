using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceListing.API.Core.Models.Place
{
    public abstract class BasePlaceDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
