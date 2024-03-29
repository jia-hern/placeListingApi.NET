using AutoMapper;
using PlaceListing.API.Core.Interfaces;
using PlaceListing.API.Data;
using PlaceListing.API.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceListing.API.Core.Repository
{
    public class PlacesRepository : GenericRepository<Place>, IPlacesRepository
    {
        public PlacesRepository(PlaceListingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
