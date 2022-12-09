using Gesc.Features.Dtos.Config.Filieres;
using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Features.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliereController : ControllerBase
    {
        private readonly IServiceDeFiliere _service;

        public FiliereController(IServiceDeFiliere service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUneFiliere(FiliereACreerDto filiereAAjouterDto)
        {
            var result = await _service.AjouterUneFiliere(filiereAAjouterDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<FiliereDto>>> LireTousLesFilieres()
        {
            var result = await _service.LireToutesLesFilieres();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FiliereDto>> LireUneFiliere(Guid id)
        {
            var result = await _service.LireDetailDuneFiliere(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneFiliere(Guid filiereId, FiliereAModifierDto filiereAModifierDto)
        {
            var resultat = await _service.ModifierUneFiliere(filiereId, filiereAModifierDto);
            return Ok(resultat);
        }
    }
}