using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Departments.GetAllAsync());
        }

        [HttpGet]
        [Route("GetDepartment/{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(id);
            return Ok(existingDepartment);
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(Department department)
        {
            var result = await _unitOfWork.Departments.CreateAsync(department);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(Department department)
        {
            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(department.Id);

            if (existingDepartment is null)
            {
                var exception = new Exception($"Department type {department.Id} was not found");
                throw exception;
            }

            var details = new Department.DepartmentDetails(department.Name);
            existingDepartment.UpdateDetails(details);
            await _unitOfWork.Departments.UpdateAsync(existingDepartment);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.Departments.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
