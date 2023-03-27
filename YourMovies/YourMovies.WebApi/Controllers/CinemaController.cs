using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCinema")]
        public async Task<IActionResult> Get()
        {
            var cinema = await _unitOfWork.Cinema.GetAllAsync();
            cinema.ToList();

            for (var index = 0; index < cinema.Count; index++)
            {
                var ageRating = await _unitOfWork.AgeRatings.GetByIdAsync(cinema[index].AgeRatingId);
                var typeCinema = await _unitOfWork.TypeCinema.GetByIdAsync(cinema[index].TypeCinemaId);
                var ganre = await _unitOfWork.Ganres.GetByIdAsync(cinema[index].GanreId);
                var country = await _unitOfWork.Countrys.GetByIdAsync(cinema[index].CountryId);
                var productionCompany = await _unitOfWork.ProductionCompanys.GetByIdAsync(cinema[index].ProductionCompanyId);

                cinema[index].AgeRating = ageRating;
                cinema[index].TypeCinema = typeCinema;
                cinema[index].Ganre = ganre;
                cinema[index].Country = country;
                cinema[index].ProductionCompany = productionCompany;
            }

            return Ok(cinema);
        }

        [HttpGet]
        [Route("GetCinema/{id}")]
        public async Task<IActionResult> GetCinemaById(Guid id)
        {
            var existingCinema = await _unitOfWork.Cinema.GetByIdAsync(id);
            return Ok(existingCinema);
        }

        [HttpPost]
        [Route("AddCinema")]
        public async Task<IActionResult> Post(Cinema cinema)
        {
            var ageRating = await _unitOfWork.AgeRatings.GetByIdAsync(cinema.AgeRatingId);
            var typeCinema = await _unitOfWork.TypeCinema.GetByIdAsync(cinema.TypeCinemaId);
            var ganre = await _unitOfWork.Ganres.GetByIdAsync(cinema.GanreId);
            var country = await _unitOfWork.Countrys.GetByIdAsync(cinema.CountryId);
            var productionCompany = await _unitOfWork.ProductionCompanys.GetByIdAsync(cinema.ProductionCompanyId);

            cinema.AgeRating = ageRating;
            cinema.TypeCinema = typeCinema;
            cinema.Ganre = ganre;
            cinema.Country = country;
            cinema.ProductionCompany = productionCompany;

            var result = await _unitOfWork.Cinema.CreateAsync(cinema);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateCinema")]
        public async Task<IActionResult> Put(Cinema cinema)
        {
            var existingCinema = await _unitOfWork.Cinema.GetByIdAsync(cinema.Id);

            if (existingCinema is null)
            {
                var exception = new Exception($"Cinema type {cinema.Id} was not found");
                throw exception;
            }

            var details = new Cinema.CinemaDetails(cinema.AgeRating, cinema.AgeRatingId, cinema.TypeCinema, cinema.TypeCinemaId, cinema.Ganre, cinema.GanreId, cinema.Country, cinema.CountryId, cinema.ProductionCompany, cinema.ProductionCompanyId, cinema.Name, cinema.Description, cinema.ReleaseDate,
                cinema.MainImage, cinema.FilmBudget);
            existingCinema.UpdateDatails(details);
            await _unitOfWork.Cinema.UpdateAsync(existingCinema);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeleteCinema/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.Cinema.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
