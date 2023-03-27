
using Microsoft.AspNetCore.Mvc;
using System;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetPerson")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Persons.GetAllAsync());
        }

        [HttpGet]
        [Route("GetPerson/{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var existingPerson = await _unitOfWork.Persons.GetByIdAsync(id);
            return Ok(existingPerson);
        }

        [HttpPost]
        [Route("AddPerson")]
        public async Task<IActionResult> Post(Person person)
        {
            var result = await _unitOfWork.Persons.CreateAsync(person);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public async Task<IActionResult> Put(Person person)
        {
            var existingPerson = await _unitOfWork.Persons.GetByIdAsync(person.Id);

            if (existingPerson is null)
            {
                var exception = new Exception($"Person type {person.Id} was not found");
                throw exception;
            }

            var details = new Person.PersonDetails(person.Name, person.Surname);
            existingPerson.UpdateDetails(details);
            await _unitOfWork.Persons.UpdateAsync(existingPerson);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeletePerson/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.Persons.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
