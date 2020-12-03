using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Business.Abstract;
using CarDealer.DataAccess.DataTransferObjects;
using CarDealer.Entities;
using Microsoft.AspNetCore.Mvc;
using Security.Helpers;

namespace CarDealer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarService _carManager;
        private readonly IMapper _mapper;

        public CarsController(ICarService carManager, IMapper mapper)
        {
            _carManager = carManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carManager.GetAllCars();
            return Ok(_mapper.Map<List<ReadDto>>(cars));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carManager.GetCarById(id);

            if (car == null) return NotFound();

            return Ok(_mapper.Map<ReadDto>(car));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]Car createDto)
        {
            var car = _mapper.Map<Car>(createDto);
            var newCar = await _carManager.CreateCar(car);
            var mappedCar = _mapper.Map<ReadDto>(newCar);
            return CreatedAtAction("GetCarById", new { id = mappedCar.Id }, mappedCar);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody]Car UpdateDto)
        {
            if (await _carManager.GetCarById(UpdateDto.Id) == null)
                return NotFound();

            var car = _mapper.Map<Car>(UpdateDto);
            car = await _carManager.UpdateCar(car);

            return Ok(_mapper.Map<ReadDto>(car));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (await _carManager.GetCarById(id) == null)
                return NotFound();

            return Ok(await _carManager.DeleteCar(id));
        }
    }
}
