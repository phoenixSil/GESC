using AutoMapper;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Domain.Modeles.Config;
using Gesc.Api.Proxies.GdcProxys.Contrats;
using Gesc.Api.Services.Contrats;
using MsCommun.Reponses;

namespace Gesc.Api.Proxies.GdcProxys
{
    public class GdcProxy: IGdcProxy
    {
        private readonly HttpClient _httpClient;
        private readonly IServiceDeFiliere _serviceFiliere;
        private readonly IServiceDeCycle _serviceCycle;
        public GdcProxy(IServiceDeCycle serviceCycle, IServiceDeFiliere serviceFiliere, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _serviceFiliere = serviceFiliere;
            _serviceCycle = serviceCycle;
        }

        public async Task<ReponseDeRequette> AjoutterNiveau(Niveau niveau)
        {
            var dto = await GenerateDtoNiveauxPourGie(niveau);
            var niveauStringContent = UtilProxy.SerializeRequette(dto);
            var response = await _httpClient.PostAsync($"Cours/Niveau", niveauStringContent).ConfigureAwait(false);

            await UtilProxy.VerifierSiLappelAEchouer(response).ConfigureAwait(false);

            var parsed = await UtilProxy.DeserializeHttpResponse<ReponseDeRequette>(response);

            if (parsed.Success)
                return parsed;
            throw new Exception($" parsed na pas marcher {parsed}");
        }

        private async Task<NiveauGdcACreerDto> GenerateDtoNiveauxPourGie(Niveau niveau)
        {
            var CycleDetail = await _serviceCycle.LireDetailDunCycle(niveau.FiliereCycle.CycleId).ConfigureAwait(false);
            var filiereDetail = await _serviceFiliere.LireDetailDuneFiliere(niveau.FiliereCycle.FiliereId).ConfigureAwait(false);

            var dto = new NiveauGdcACreerDto
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

