using Gesc.Features.Dtos.Config.Cycles;
using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Features.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleController : ControllerBase
    {
        private readonly IServiceDeCycle _service;

        public CycleController(IServiceDeCycle service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnCycle(CycleACreerDto etudiantAAjouterDto)
        {
            var result = await _service.AjouterUnCycle(etudiantAAjouterDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CycleDto>>> LireTousLesCycles()
        {
            var result = await _service.LireTousLesCycles();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CycleDto>> LireUnCycle(Guid id)
        {
            var result = await _service.LireDetailDunCycle(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnCycle(Guid etudiantId, CycleAModifierDto etudiantAModifierDto)
        {
            var resultat = await _service.ModifierUnCycle(etudiantId, etudiantAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnCycle(Guid id)
        {
            var resultat = await _service.SupprimerUnCycle(id);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}
