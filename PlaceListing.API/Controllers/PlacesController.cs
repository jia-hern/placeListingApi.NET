using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaceListing.API.Core.Interfaces;
using PlaceListing.API.Core.Models;
using PlaceListing.API.Core.Models.Place;

namespace PlaceListing.API.NET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlacesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPlacesRepository _placesRepository;
        private readonly ILogger<PlacesController> _logger;

        public PlacesController(IMapper mapper, IPlacesRepository placesRepository, ILogger<PlacesController> logger)
        {
            this._mapper = mapper;
            this._placesRepository = placesRepository;
            this._logger = logger;
        }

        // GET: api/Places/GetAll
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PlaceDto>>> GetPlaces()
        {
            _logger.LogInformation("GetPlaces api called");
            var places = await _placesRepository.GetAllAsync<PlaceDto>();
            return Ok(places);
        }

        // GET: api/Places/?StartIndex=0&PageSize=25&PageNumber=1
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedResult<PlaceDto>>> GetPagedPlaces([FromQuery] QueryParameters queryParameters)
        {
            _logger.LogInformation("GetPagedPlaces api called");
            var pagedPlacesResult = await _placesRepository.GetAllAsync<PlaceDto>(queryParameters);
            return Ok(pagedPlacesResult);
        }

        // GET: api/Places/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlaceDto>> GetPlace(int id)
        {
            _logger.LogInformation("GetPlace api called");
            var place = await _placesRepository.GetAsync<PlaceDto>(id);
            return Ok(place);
        }

        // PUT: api/Places
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutPlace(PlaceDto placeDto)
        {
            _logger.LogInformation("PutPlace api called");
            try
            {
                await _placesRepository.UpdateAsync(placeDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _placesRepository.Exists(placeDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Places
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PlaceDto>> PostPlace(CreatePlaceDto placeDto)
        {
            _logger.LogInformation("PostPlace api called");
            var place = await _placesRepository.AddAsync<CreatePlaceDto, PlaceDto>(placeDto);
            return CreatedAtAction(nameof(GetPlace), new { id = place.Id }, place);
        }

        // DELETE: api/Places/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeletePlace(int id)
        {
            _logger.LogInformation("DeletePlace api called");
            await _placesRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}