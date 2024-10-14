using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using T.DataAccess.Services.Interfaces;
using T.Models.DTOs;
using T.Models.Models;

namespace TechTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;
        public CandidatoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _service = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Candidato.ListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.Candidato.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CandidatoDto candidato)
        {
            var model = _service.Candidato.Add(_mapper.Map<Candidato>(candidato));
            await _service.SaveAsync();

            return Ok(model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, CandidatoDto model)
        {
            var candidato = await _service.Candidato.GetByIdAsync(model.ID);

            if (id != model.ID)
                return BadRequest("Identificador Invalido");

            if (candidato == null)
                return NotFound();

            _mapper.Map(model, candidato);
            _service.Candidato.Update(candidato);
            await _service.SaveAsync();
            return Ok(model);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await _service.Candidato.GetByIdAsync(id);

            if (candidato == null)
                return NotFound();

            _service.Candidato.Remove(candidato);
            await _service.SaveAsync();
            return Ok("Candidato Eliminado");
        }
    }
}
