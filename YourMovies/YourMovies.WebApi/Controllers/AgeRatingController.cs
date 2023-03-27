using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeRatingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgeRatingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAgeRating")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.AgeRatings.GetAllAsync());
        }

        [HttpGet]
        [Route("GetAgeRating/{id}")]
        public async Task<IActionResult> GetAgeRatingById(Guid id)
        {
            var existingAgeRating = await _unitOfWork.AgeRatings.GetByIdAsync(id);
            return Ok(existingAgeRating);
        }

        [HttpPost]
        [Route("AddAgeRating")]
        public async Task<IActionResult> Post(AgeRating ageRating)
        {
            var result = await _unitOfWork.AgeRatings.CreateAsync(ageRating);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateAgeRating")]
        public async Task<IActionResult> Put(AgeRating ageRating)
        {
            var existingAgeRating = await _unitOfWork.AgeRatings.GetByIdAsync(ageRating.Id);

            if (existingAgeRating is null)
            {
                var exception = new Exception($"AgeRating type {ageRating.Id} was not found");
                throw exception;
            }

            var details = new AgeRating.AgeRatingDetails(ageRating.Name, ageRating.ViewAge, ageRating.Description);
            existingAgeRating.UpdateDatails(details);
            await _unitOfWork.AgeRatings.UpdateAsync(existingAgeRating);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeleteAgeRating/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.AgeRatings.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
