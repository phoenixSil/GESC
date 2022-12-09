using Gesc.Features.Dtos.Config.Departements;
using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Features.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IServiceDeDepartement _service;

        public DepartementController(IServiceDeDepartement service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReponseDeRequette>> AjouterUnDepartement(DepartementACreerDto departementAAjouterDto)
        {
            var result = await _service.AjouterUnDepartement(departementAAjouterDto);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DepartementDto>>> LireTousLesDepartements()
        {
            var result = await _service.LireTousLesDepartements();

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("ecole/{ecoleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<DepartementDto>>> LireTousLesDepartementDuneEcoleParEcoleId(Guid ecoleId)
        {
            var result = await _service.LireTousLesDepartementDuneEcoleParEcoleId(ecoleId);

            if (result == null || result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartementDto>> LireUnDepartement(Guid id)
        {
            var result = await _service.LireDetailDunDepartement(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartementDto>> LireDetailDUnDepartement(Guid id)
        {
            var result = await _service.LireDetailInfoDunDepartement(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReponseDeRequette>> ModifierUnDepartement(Guid departementId, DepartementAModifierDto departementAModifierDto)
        {
            var resultat = await _service.ModifierUnDepartement(departementId, departementAModifierDto);
            return Ok(resultat);
        }
    }
}