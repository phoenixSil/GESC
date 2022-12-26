using Gesc.Features.Dtos.Config.FiliereCycles;
using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;
using Polly.Caching;

namespace Gesc.Features.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliereCycleController : ControllerBase
    {
        private readonly IServiceDeFiliereCycle _service;

        public FiliereCycleController(IServiceDeFiliereCycle service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneFiliereCycle(FiliereCycleACreerDto filiereCycleAAjouterDto)
        {
            var result = await _service.AjouterUneFiliereCycle(filiereCycleAAjouterDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<FiliereCycleDto>>> LireTousLesFiliereCycles()
        {
            var result = await _service.LireToutesLesFiliereCycles();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FiliereCycleDto>> LireUneFiliereCycle(Guid id)
        {
            var result = await _service.LireDetailDuneFiliereCycle(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneFiliereCycle(Guid id, FiliereCycleAModifierDto filiereCycleAModifierDto)
        {
            var resultat = await _service.ModifierUneFiliereCycle(id, filiereCycleAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUneFiliereCycle(Guid id)
        {
            var resultat = await _service.SupprimerUneFiliereCycle(id);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
