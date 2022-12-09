using AutoMapper;
using Gesc.Domain.Modeles.Config;
using MsCommun.Reponses;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Gesc.Features.Contrats.Proxies;
using Gesc.Features.Services.Contrats;
using Gesc.Features.Dtos.Config.Niveaux;

namespace Gesc.Features.Proxies.GieProxys
{
    public class GieProxy : IGieProxy
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        private readonly IServiceDeFiliere _serviceFiliere;
        private readonly IServiceDeCycle _serviceCycle;
        public GieProxy(IServiceDeCycle serviceCycle,IServiceDeFiliere serviceFiliere, IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _serviceFiliere = serviceFiliere;
            _serviceCycle = serviceCycle;
        }

        public async Task<ReponseDeRequette> AjoutterNiveau(Niveau niveau)
        {
            var dto = await GenerateDtoNiveauxPourGie(niveau);
            var niveauStringContent = UtilProxy.SerializeRequette(dto);
            var response = await _httpClient.PostAsync($"Etudiant/Niveau", niveauStringContent).ConfigureAwait(false);

            await UtilProxy.VerifierSiLappelAEchouer(response).ConfigureAwait(false);

            var parsed = await UtilProxy.DeserializeHttpResponse<ReponseDeRequette>(response);

            if (parsed.Success)
                return parsed;
            throw new Exception($" parsed na pas marcher {parsed}");
        }

        private async Task<NiveauGieACreerDto> GenerateDtoNiveauxPourGie(Niveau niveau)
        {
            var CycleDetail = await _serviceCycle.LireDetailDunCycle(niveau.FiliereCycle.CycleId).ConfigureAwait(false); 
            var filiereDetail = await _serviceFiliere.LireDetailDuneFiliere(niveau.FiliereCycle.FiliereId).ConfigureAwait(false);

            var dto = new NiveauGieACreerDto
            {
                Id = Guid.NewGuid(),
                Designation = niveau.Designation,
                DesignationCycle = CycleDetail.Designation,
                DesignationFiliere = filiereDetail.Designation,
                NumeroExterne = niveau.Id,
                ValeurCycle = niveau.ValeurCycle
            };

            return dto;
        }
    }
}
