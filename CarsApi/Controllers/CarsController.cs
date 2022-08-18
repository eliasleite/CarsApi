using AutoMapper;
using CarsApi.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(
            ICarRepository carRepository, 
            ICarService carService, 
            IMapper mapper)
        {
            _carRepository = carRepository;
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CarViewModel>> GetAll() 
        {
            return _mapper.Map<IEnumerable<CarViewModel>>(await _carRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CarViewModel>> GetById(Guid id)
        {
            var carViewModel = _mapper.Map<CarViewModel>(await _carRepository.GetById(id));

            if (carViewModel == null) return NotFound();

            return carViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<CarViewModel>> Add(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(carViewModel);

            await _carService.Add(_mapper.Map<Car>(carViewModel));

            return Ok(carViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid id, CarViewModel carViewModel)
        {
            if (id != carViewModel.Id) return NotFound();

            var carUpadate = await _carRepository.GetById(id);

            carUpadate.Name = carViewModel.Name;
            carUpadate.Description = carViewModel.Description;
            carUpadate.CreationDate = carViewModel.CreationDate;
            carUpadate.Price = carViewModel.Price;
            carUpadate.Active = carViewModel.Active;
            carUpadate.MakerId = carViewModel.MakerId;

            await _carService.Update(_mapper.Map<Car>(carViewModel));

            return Ok(carViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CarViewModel>> Delete(Guid id)
        {
            var carViewModel = await _carRepository.GetById(id);

            if (carViewModel == null) return NotFound();

            await _carService.Delete(id);

            return Ok(carViewModel);           

        }

    }
}
