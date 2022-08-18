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
    public class MakersController : ControllerBase
    {
        private readonly IMakerRepository _makerRepository;
        private readonly IMakerService _makerService;
        private readonly IMapper _mapper;
        public MakersController(
            IMakerRepository makerRepository, 
            IMakerService makerService, 
            IMapper mapper )
        {
            _makerRepository = makerRepository;
            _makerService = makerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MakerViewModel>> GetAll() 
        {
            return _mapper.Map<IEnumerable<MakerViewModel>>(await _makerRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MakerViewModel>> GetById(Guid id) 
        {
            var makerViewModel = _mapper.Map<MakerViewModel>(await _makerRepository.GetById(id));

            if (makerViewModel == null) return NotFound();

            return makerViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<MakerViewModel>> Add(MakerViewModel makerViewModel) 
        {
            if (!ModelState.IsValid) return BadRequest(makerViewModel);

            await _makerService.Add(_mapper.Map<Maker>(makerViewModel));

            return Ok(makerViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid id,MakerViewModel makerViewModel) 
        {
            if (id != makerViewModel.Id) return NotFound();

            var makerUpadate = await _makerRepository.GetById(id);

            makerUpadate.Name = makerViewModel.Name;
            makerUpadate.Active = makerViewModel.Active;

            await _makerService.Update(_mapper.Map<Maker>(makerViewModel));

            return Ok(makerViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<MakerViewModel>> Delete(Guid id) 
        {
            var makerViewModel = await _makerRepository.GetById(id);

            if (makerViewModel == null) return NotFound();

            await _makerService.Delete(id);

            return Ok(makerViewModel);

        }
    }
}
