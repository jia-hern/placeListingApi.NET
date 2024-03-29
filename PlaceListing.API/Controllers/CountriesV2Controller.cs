using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using PlaceListing.API.Core.Interfaces;
using PlaceListing.API.Core.Models;
using PlaceListing.API.Core.Models.Country;

namespace PlaceListing.API.NET6.Controllers
{
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CountriesV2Controller : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;
        private readonly ILogger<CountriesController> _logger;

        public CountriesV2Controller(IMapper mapper, ICountriesRepository countriesRepository, ILogger<CountriesController> logger)
        {
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
            this._logger = logger;
        }

        // GET: api/v2/Countries
        // GET: api/v2/Countries?$select=name
        // GET: api/v2/Countries?$select=name,natCode
        // GET: api/v2/Countries?$filter=name eq 'Singapore'
        // GET: api/v2/Countries?$orderby=name
        // GET: api/v2/Countries?$select=name,natCode&$filter=name eq 'Singapore'&$orderby=name
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            _logger.LogInformation("GetCountries api v2.0 called");
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }


        // GET: api/v2/Countries/Paged/?StartIndex=0&PageSize=25&PageNumber=1
        [HttpGet("Paged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            _logger.LogInformation("GetPagedCountries api called");
            var pagedCountriesResult = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParameters);
            return Ok(pagedCountriesResult);
        }

        // GET: api/v2/Countries/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
        {
            _logger.LogInformation("GetCountry api called");
            var country = await _countriesRepository.GetCountryDetailsOfPlace(id);
            return Ok(country);
        }


        // PUT: api/v2/Countries
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCountry(UpdateCountryDto updateCountryDto)
        {
            _logger.LogInformation("PutCountry api called");
            try
            {
                await _countriesRepository.UpdateAsync(updateCountryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _countriesRepository.Exists(updateCountryDto.Id))
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

        // POST: api/v2/Countries
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CountryDto>> PostCountry(CreateCountryDto createCountryDto)
        {
            _logger.LogInformation("PostCountry api called");
            var country = await _countriesRepository.AddAsync<CreateCountryDto, GetCountryDto>(createCountryDto);
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // DELETE: api/v2/Countries/1
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            _logger.LogInformation("DeleteCountry api called");
            await _countriesRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}