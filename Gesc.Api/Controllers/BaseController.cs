using Gesc.Features.Services.Contrats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gesc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IServiceDeNiveau _serviceDeNiveau;
        protected readonly IServiceDeCycle _serviceDeCycle;
        protected readonly IServiceDecole _serviceDecole;
        protected readonly IServiceDeFiliere _serviceDeFiliere;
        protected readonly IServiceDeDepartement _serviceDeDepartement;
        protected readonly IServiceDeFiliereCycle _serviceDeFiliereCycle;

        public BaseController(IServiceDeFiliereCycle serviceDeFiliereCycle, IServiceDeDepartement serviceDeDepartement, IServiceDeFiliere serviceDeFiliere, IServiceDecole serviceDecole, IServiceDeCycle serviceDeCycle, IServiceDeNiveau serviceDeNiveau)
        {
            _serviceDeFiliereCycle = serviceDeFiliereCycle;
            _serviceDeDepartement = serviceDeDepartement;
            _serviceDeFiliere = serviceDeFiliere;
            _serviceDecole = serviceDecole;
            _serviceDeCycle = serviceDeCycle;
            _serviceDeNiveau = serviceDeNiveau;
        }


    }
}
