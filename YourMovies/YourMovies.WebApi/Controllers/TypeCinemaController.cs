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
        public async Task<IActionResult> GetTypeCinema()
        {
            return Ok(await _unitOfWork.TypeCinema.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeCinemaById(Guid id)
        {
            var existingTypeCinema = await _unitOfWork.TypeCinema.GetByIdAsync(id);
            return Ok(existingTypeCinema);
        }

        [HttpPost]
        public async Task<IActionResult> AddTypeCinema([FromBody]TypeCinema typeCinema)
        {
            var result = await _unitOfWork.TypeCinema.CreateAsync(typeCinema);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTypeCinema([FromBody] TypeCinema typeCinema)
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

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteTypeCinema(Guid id)
        {
            await _unitOfWork.TypeCinema.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
