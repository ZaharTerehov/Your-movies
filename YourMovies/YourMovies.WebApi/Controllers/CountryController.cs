using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountry()
        {
            return Ok(await _unitOfWork.Countrys.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            var existingGanre = await _unitOfWork.Countrys.GetByIdAsync(id);
            return Ok(existingGanre);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody]Country country)
        {
            var result = await _unitOfWork.Countrys.CreateAsync(country);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody]Country country)
        {
            var existingCountry = await _unitOfWork.Countrys.GetByIdAsync(country.Id);

            if (existingCountry is null)
            {
                var exception = new Exception($"Country type {country.Id} was not found");
                throw exception;
            }

            Country.CountryDetails details = new Country.CountryDetails(country.Name, country.ISOCode);
            existingCountry.UpdateDetails(details);
            await _unitOfWork.Countrys.UpdateAsync(existingCountry);

            return Ok("Update successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteCountry(Guid id)
        {
            await _unitOfWork.Countrys.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
