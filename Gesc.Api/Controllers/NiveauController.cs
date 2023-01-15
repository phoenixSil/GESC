using Gesc.Features.Dtos.Config.Niveaux;
using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Features.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NiveauController : ControllerBase
    {
        private readonly IServiceDeNiveau _service;

        public NiveauController(IServiceDeNiveau service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnNiveau(NiveauACreerDto niveauAAjouterDto)
        {
            var result = await _service.AjouterUnNiveau(niveauAAjouterDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<NiveauDto>>> LireTousLesNiveaus()
        {
            var result = await _service.LireTousLesNiveaus();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NiveauDto>> LireUnNiveau(Guid id)
        {
            var result = await _service.LireDetailDunNiveau(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnNiveau(Guid id, NiveauAModifierDto niveauAModifierDto)
        {
            var resultat = await _service.ModifierUnNiveau(id, niveauAModifierDto);
            return StatusCode(resultat.StatusCode, resultat);
        }

        [HttpDelete("{niveauId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> SupprimerUnNiveau(Guid niveauId)
        {
            var resultat = await _service.SupprimerUnNiveau(niveauId);
            return StatusCode(resultat.StatusCode, resultat);
        }
    }
}

