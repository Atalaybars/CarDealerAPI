using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Business.Abstract;
using CarDealer.Entities;
using Microsoft.AspNetCore.Mvc;
using Security.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private ICarService _carManager;

        public CarsController(ICarService carManager)
        {
            _carManager = carManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carManager.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carManager.GetCarById(id);

            if (car == null) return NotFound();

            return Ok(car);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody]Car car)
        {
            var newCar = await _carManager.CreateCar(car);
            return CreatedAtAction("GetCarById", new { id = newCar.Id }, newCar);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody]Car car)
        {
            if (await _carManager.GetCarById(car.Id) == null)
                return NotFound();
            
            return Ok(await _carManager.UpdateCar(car));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (await _carManager.GetCarById(id) == null)
                return NotFound();

            await _carManager.DeleteCar(id);
            return Ok();
        }
    }
}
