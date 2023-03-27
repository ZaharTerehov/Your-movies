using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

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
        [Route("GetProductionCompany")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.ProductionCompanys.GetAllAsync());
        }

        [HttpGet]
        [Route("GetProductionCompany/{id}")]
        public async Task<IActionResult> GetProductionCompanyById(Guid id)
        {
            var existingProductionCompany = await _unitOfWork.ProductionCompanys.GetByIdAsync(id);
            return Ok(existingProductionCompany);
        }

        [HttpPost]
        [Route("AddProductionCompany")]
        public async Task<IActionResult> Post(ProductionCompany productionCompany)
        {
            var result = await _unitOfWork.ProductionCompanys.CreateAsync(productionCompany);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateProductionCompany")]
        public async Task<IActionResult> Put(ProductionCompany productionCompany)
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

        [HttpDelete]
        [Route("DeleteProductionCompany/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.ProductionCompanys.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
