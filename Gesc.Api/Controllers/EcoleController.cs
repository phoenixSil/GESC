using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace GCE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcoleController : ControllerBase
    {
        private readonly IServiceDecole _service;

        public EcoleController(IServiceDecole service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnecole(EcoleACreerDto ecoleAAjouterDto)
        {
            var result = await _service.AjouterUneEcole(ecoleAAjouterDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EcoleDto>>> LireTousLesEcoles()
        {
            var result = await _service.LireToutesLesEcoles();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EcoleDto>> LireUnecole(Guid id)
        {
            var result = await _service.LireDetailDuneEcole(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnecole(Guid ecoleId, EcoleAModifierDto ecoleAModifierDto)
        {
            var resultat = await _service.ModifierUneEcole(ecoleId, ecoleAModifierDto);
            return Ok(resultat);
        }
    }
}