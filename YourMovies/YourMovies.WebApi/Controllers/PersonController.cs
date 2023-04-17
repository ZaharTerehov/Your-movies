
using Microsoft.AspNetCore.Mvc;
using System;
using YourMovies.Domain.Entities;
using YourMovies.Application.Interfaces;

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
        public async Task<IActionResult> GetPerson()
        {
            return Ok(await _unitOfWork.Persons.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var existingPerson = await _unitOfWork.Persons.GetByIdAsync(id);
            return Ok(existingPerson);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody]Person person)
        {
            var result = await _unitOfWork.Persons.CreateAsync(person);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody]Person person)
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

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeletePerson(Guid id)
        {
            await _unitOfWork.Persons.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
