using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Controllers
{
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        public CarsController(DevCarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/cars
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna lista de CarItemViewModel
            var cars = _dbContext.Cars;

            var carsViewModel = cars
                .Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model, c.Price))
                .ToList();

            return Ok(carsViewModel);
        }

        // GET api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // SE CARRO DE IDENTIFICADOR ID NÃO EXISTIR, RETORNA NOTFOUND
            // SENAO, OK

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carDetailsViewModel = new CarDetailsViewModel(
                car.Id,
                car.Brand,
                car.Model,
                car.VinCode,
                car.Year,
                car.Price,
                car.Color,
                car.ProductionDate
                );


            return Ok(carDetailsViewModel);
        }

        // POST api/cars
        [HttpPost]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            // SE O CADASTRO FUNCIONAR, RETORNA CREATED (201)
            // SE OS DADOS DE ENTRADA ESTIVEREM INCORRETOS, RETORNA BAD REQUEST (400)
            // SE O CADASTRO FUNCIONAR, MAS NAO TIVER UMA API DE CONSULTA, RETORNA NOCONTENT(204)

            if (model.Model.Length > 50)
            {
                return BadRequest("Modelo não pode ter mais de 50 caracteres.");
            }

            var car = new Car(4, model.VinCode, model.Brand, model.Model, model.Year, model.Price, model.Color, model.ProductionDate);

            _dbContext.Cars.Add(car);

            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id },
                model
                );
        }

        // PUT api/cars/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            // SE A ATUALIZAÇÃO FUNCIONAR, RETORNA 204 NO CONTENT
            // SE DADOS DE ENTRADA ESTIVEREM INCORRETOS, RETORNA 400 BAD REQUEST
            // SE NAO EXISTIR, RETORNA NOT FOUND 404

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.Update(model.Color, model.Price);

            return NoContent();
        }

        // DELETE api/cars/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // SE NAO EXISTIR, RETORNA NOT FOUND 404
            //  SE FOR COM SUCESSO, RETORNA NO CONTENT 204

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.SetAsSuspended();

            return NoContent();
        }
    }
}
