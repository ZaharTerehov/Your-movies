using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GanreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GanreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private static readonly IEnumerable<Ganre> Items = new[]
        {
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
            new Ganre {Name = "Test Name", Description = "Test Description"},
        };

        [HttpGet]
        [Route("GetGanre")]
        public IEnumerable<Ganre> Get()
        {
            return Items;
        }

        [HttpGet]
        [Route("GetGanre/{id}")]
        public async Task<IActionResult> GetGanreById(Guid id)
        {
            var existingGanre = await _unitOfWork.Ganres.GetByIdAsync(id);
            return Ok(existingGanre);
        }

        [HttpPost]
        [Route("AddGanre")]
        public async Task<IActionResult> Post(Ganre ganre)
        {
            var result = _unitOfWork.Ganres.CreateAsync(ganre);

            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateGanre")]
        public async Task<IActionResult> Put(Ganre ganre)
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

        [HttpDelete]
        [Route("DeleteGanre")]
        public JsonResult Delete(Guid id)
        {

        }
    }
}
