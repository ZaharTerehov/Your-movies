﻿
using Microsoft.AspNetCore.Mvc;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaCrewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CinemaCrewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCinemaCrew")]
        public async Task<IActionResult> Get()
        {
            var cinemaCrews = await _unitOfWork.CinemaCrews.GetAllAsync();
            cinemaCrews.ToList();

            for (var index = 0; index < cinemaCrews.Count; index++)
            {
                var person = await _unitOfWork.Persons.GetByIdAsync(cinemaCrews[index].PersonId);
                var department = await _unitOfWork.Departments.GetByIdAsync(cinemaCrews[index].DepartmentId);
                var cinema = await _unitOfWork.Cinema.GetByIdAsync(cinemaCrews[index].CinemaId);

                cinemaCrews[index].Person = person;
                cinemaCrews[index].Department = department;
                cinemaCrews[index].Cinema = cinema;
            }

            return Ok(cinemaCrews);
        }

        [HttpGet]
        [Route("GetCinemaCrew/{id}")]
        public async Task<IActionResult> GetCinemaCrewById(Guid id)
        {
            var existingCinemaCrew = await _unitOfWork.CinemaCrews.GetByIdAsync(id);
            return Ok(existingCinemaCrew);
        }

        [HttpPost]
        [Route("AddCinemaCrew")]
        public async Task<IActionResult> Post(CinemaCrew cinemaCrew)
        {
            var person = await _unitOfWork.Persons.GetByIdAsync(cinemaCrew.PersonId);
            var department = await _unitOfWork.Departments.GetByIdAsync(cinemaCrew.DepartmentId);
            var cinema = await _unitOfWork.Cinema.GetByIdAsync(cinemaCrew.CinemaId);

            cinemaCrew.Person = person;
            cinemaCrew.Department = department;
            cinemaCrew.Cinema = cinema;

            var result = await _unitOfWork.CinemaCrews.CreateAsync(cinemaCrew);

            if (result.Id == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            return Ok("Added successfully");
        }

        [HttpPut]
        [Route("UpdateCinemaCrew")]
        public async Task<IActionResult> Put(CinemaCrew cinemaCrew)
        {
            var existingCinemaCrew = await _unitOfWork.CinemaCrews.GetByIdAsync(cinemaCrew.Id);

            if (existingCinemaCrew is null)
            {
                var exception = new Exception($"CinemaCast type {cinemaCrew.Id} was not found");
                throw exception;
            }

            var details = new CinemaCrew.CinemaCrewDetails(cinemaCrew.Person, cinemaCrew.PersonId,
                cinemaCrew.Cinema, cinemaCrew.CinemaId, cinemaCrew.Department, cinemaCrew.DepartmentId, cinemaCrew.Job);
            existingCinemaCrew.UpdateDetails(details);
            await _unitOfWork.CinemaCrews.UpdateAsync(existingCinemaCrew);

            return Ok("Update successfuly");
        }

        [HttpDelete]
        [Route("DeleteCinemaCrew/{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _unitOfWork.CinemaCrews.DeleteAsync(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
