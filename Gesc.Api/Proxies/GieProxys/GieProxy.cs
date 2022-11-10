using AutoMapper;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Proxies.Contrats;
using MsCommun.Reponses;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Gesc.Api.Proxies.GieProxys
{
    public class GieProxy : IGieProxy
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public GieProxy(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<ReponseDeRequette> AjoutterNiveau(Niveau niveau)
        {
            var dto = _mapper.Map<NiveauPourGieDto>(niveau);
            var niveauStringContent = UtilProxy.SerializeRequette(dto);
            var response = await _httpClient.PostAsync($"Etudiant/Niveau/", niveauStringContent).ConfigureAwait(false);

            await UtilProxy.VerifierSiLappelAEchouer(response).ConfigureAwait(false);

            var parsed = await UtilProxy.DeserializeHttpResponse<ReponseDeRequette>(response);

            if (parsed.Success)
                return parsed;
            throw new Exception($" parsed na pas marcher {parsed}");
        }
    }
}
