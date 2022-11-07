using Gesc.Api.Dtos.Config.FiliereCycles;
using Gesc.Api.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Api.Controllers
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
            return Ok(result);
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
        public async Task<ActionResult<ReponseDeRequette>> ModifierUneFiliereCycle(Guid filiereCycleId, FiliereCycleAModifierDto filiereCycleAModifierDto)
        {
            var resultat = await _service.ModifierUneFiliereCycle(filiereCycleId, filiereCycleAModifierDto);
            return Ok(resultat);
        }
    }
}
