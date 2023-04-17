using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Application.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GanreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GanreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetGanre()
        {
            return Ok(await _unitOfWork.Ganres.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGanreById(Guid id)
        {
            var existingGanre = await _unitOfWork.Ganres.GetByIdAsync(id);
            return Ok(existingGanre);
        }

        [HttpPost]
        public async Task<IActionResult> AddGanre([FromBody]Ganre ganre)
        {
            var result = await _unitOfWork.Ganres.CreateAsync(ganre);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGanre([FromBody] Ganre ganre)
        {
            var existingGanre = await _unitOfWork.Ganres.GetByIdAsync(ganre.Id);

            if (existingGanre is null)
            {
                var exception = new Exception($"Ganre type {ganre.Id} was not found");
                throw exception;
            }

            Ganre.GanreDetails details = new Ganre.GanreDetails(ganre.Name, ganre.Description);
            existingGanre.UpdateDetails(details);
            await _unitOfWork.Ganres.UpdateAsync(existingGanre);

            return Ok("Update successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteGanre(Guid id)
        {
            await _unitOfWork.Ganres.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
