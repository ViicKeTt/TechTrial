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

        /// <summary>
        /// Obtiene una lista de todos los candidatos.
        /// </summary>
        /// <returns>Los candidatos correspondientes listados.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Candidato.ListAsync());
        }

        /// <summary>
        /// Obtiene un candidato por su ID.
        /// </summary>
        /// <param name="id">ID del candidato a buscar.</param>
        /// <returns>El Candidato correspondiente al ID proporcionado.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.Candidato.GetByIdAsync(id));
        }
        /// <summary>
        /// Crea un nuevo registro de Candidato.
        /// </summary>
        /// <param name="candidato">El objeto Candidato que se desea crear.</param>
        /// <returns>El Candidato creado.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CandidatoDto candidato)
        {
            var model = _service.Candidato.Add(_mapper.Map<Candidato>(candidato));
            await _service.SaveAsync();

            return Ok(model);
        }

        /// <summary>
        /// Actualiza la información de un candidato existente.
        /// </summary>
        /// <param name="id">ID del candidato a actualizar.</param>
        /// <param name="candidato">El objeto Candidato con los datos actualizados.</param>
        /// <returns>Un resultado con los datos del candidato modificados si la actualización fue exitosa.</returns>
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

        /// <summary>
        /// Elimina un candidato por su ID.
        /// </summary>
        /// <param name="id">ID del candidato a eliminar.</param>
        /// <returns>Un resultado con mensaje de confirmación si la eliminación fue exitosa.</returns>
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
