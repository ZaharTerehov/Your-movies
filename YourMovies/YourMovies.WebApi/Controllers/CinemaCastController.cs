
using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Application.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaCastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaCastController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemaCast()
        {
            var cinemaCasts = await _unitOfWork.CinemaCasts.GetAllAsync();
            cinemaCasts.ToList();

            for (var index = 0; index < cinemaCasts.Count; index++)
            {
                var person = await _unitOfWork.Persons.GetByIdAsync(cinemaCasts[index].PersonId);
                var cinema = await _unitOfWork.Cinema.GetByIdAsync(cinemaCasts[index].CinemaId);
                cinemaCasts[index].Person = person;
                cinemaCasts[index].Cinema = cinema;
            }

            return Ok(cinemaCasts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCinemaCastById(Guid id)
        {
            var existingCinemaCast = await _unitOfWork.CinemaCasts.GetByIdAsync(id);
            return Ok(existingCinemaCast);
        }

        [HttpPost]
        public async Task<IActionResult> AddCinemaCast([FromBody] CinemaCast cinemaCast)
        {
            var person = await _unitOfWork.Persons.GetByIdAsync(cinemaCast.PersonId);
            var cinema = await _unitOfWork.Cinema.GetByIdAsync(cinemaCast.CinemaId);

            cinemaCast.Person = person;
            cinemaCast.Cinema = cinema;

            var result = await _unitOfWork.CinemaCasts.CreateAsync(cinemaCast);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCinemaCast([FromBody] CinemaCast cinemaCast)
        {
            var existingCinemaCast = await _unitOfWork.CinemaCasts.GetByIdAsync(cinemaCast.Id);

            if (existingCinemaCast is null)
            {
                var exception = new Exception($"CinemaCast type {cinemaCast.Id} was not found");
                throw exception;
            }

            var details = new CinemaCast.CinemaCastDetails(cinemaCast.Person, cinemaCast.PersonId,
                cinemaCast.Cinema, cinemaCast.CinemaId, cinemaCast.CharacterName, (decimal)cinemaCast.CastOrder);

            existingCinemaCast.UpdateDetails(details);
            await _unitOfWork.CinemaCasts.UpdateAsync(existingCinemaCast);

            return Ok("Update successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteCinemaCast(Guid id)
        {
            await _unitOfWork.CinemaCasts.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
