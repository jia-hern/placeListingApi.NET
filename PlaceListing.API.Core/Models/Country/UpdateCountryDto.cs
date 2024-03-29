using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceListing.API.Core.Models.Country
{
    public class UpdateCountryDto : BaseCountryDto, IBaseIdDto
    {
        public int Id { get; set; }
    }
}
