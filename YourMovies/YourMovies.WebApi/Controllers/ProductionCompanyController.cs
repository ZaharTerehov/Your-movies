using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Application.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductionCompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductionCompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductionCompany()
        {
            return Ok(await _unitOfWork.ProductionCompanys.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionCompanyById(Guid id)
        {
            var existingProductionCompany = await _unitOfWork.ProductionCompanys.GetByIdAsync(id);
            return Ok(existingProductionCompany);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductionCompany([FromBody]ProductionCompany productionCompany)
        {
            var result = await _unitOfWork.ProductionCompanys.CreateAsync(productionCompany);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductionCompany([FromBody]ProductionCompany productionCompany)
        {
            var existingProductionCompany = await _unitOfWork.ProductionCompanys.GetByIdAsync(productionCompany.Id);

            if (existingProductionCompany is null)
            {
                var exception = new Exception($"ProductionCompany type {productionCompany.Id} was not found");
                throw exception;
            }

            var details = new ProductionCompany.ProductionCompanyDetails(productionCompany.Name);
            existingProductionCompany.UpdateDetails(details);
            await _unitOfWork.ProductionCompanys.UpdateAsync(existingProductionCompany);

            return Ok("Update successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteProductionCompany(Guid id)
        {
            await _unitOfWork.ProductionCompanys.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
