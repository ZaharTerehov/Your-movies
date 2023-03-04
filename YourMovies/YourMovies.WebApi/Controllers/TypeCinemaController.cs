using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeCinemaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeCinemaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetTypeCinema")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.TypeCinema.GetAllAsync());
        }

        [HttpGet]
        [Route("GetTypeCinema/{id}")]
        public async Task<IActionResult> GetTypeCinemaById(Guid id)
        {
            var existingTypeCinema = await _unitOfWork.TypeCinema.GetByIdAsync(id);
            return Ok(existingTypeCinema);
        }

        [HttpPost]
        [Route("AddTypeCinema")]
        public async Task<IActionResult> Post(TypeCinema typeCinema)
        {
            var result = await _unitOfWork.TypeCinema.CreateAsync(typeCinema);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateTypeCinema")]
        public async Task<IActionResult> Put(TypeCinema typeCinema)
        {
            var existingTypeCinema = await _unitOfWork.TypeCinema.GetByIdAsync(typeCinema.Id);

            if (existingTypeCinema is null)
            {
                var exception = new Exception($"TypeCinema type {typeCinema.Id} was not found");
                throw exception;
            }

            TypeCinema.TypeCinemaDetails details = new TypeCinema.TypeCinemaDetails(typeCinema.Name);
            existingTypeCinema.UpdateDetails(details);
            await _unitOfWork.TypeCinema.UpdateAsync(existingTypeCinema);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeleteTypeCinema/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.TypeCinema.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
