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
        [Route("GetCountry")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Countrys.GetAllAsync());
        }

        [HttpGet]
        [Route("GetCountry/{id}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            var existingGanre = await _unitOfWork.Countrys.GetByIdAsync(id);
            return Ok(existingGanre);
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<IActionResult> Post(Country country)
        {
            var result = await _unitOfWork.Countrys.CreateAsync(country);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateCountry")]
        public async Task<IActionResult> Put(Country country)
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

        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.Countrys.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
