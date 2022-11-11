﻿using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Modeles.Config;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Gesc.Api.Proxies
{
    public static class UtilProxy
    {
        public static StringContent SerializeRequette(NiveauGieACreerDto dto)
        {
            return new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");
        }

        public static async Task VerifierSiLappelAEchouer(HttpResponseMessage response)
        {
           if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new InvalidOperationException("La Route na pas ete trouver ");
           if(response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Internal Server Exception Error ");
            }
        }

        static public async Task<T> DeserializeHttpResponse<T>(HttpResponseMessage resultCall)
        {
            var stream = await resultCall.Content.ReadAsStreamAsync();
            T t = await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return t;
        }

        public static NiveauGieACreerDto GenerateDtoNiveauxPourGie(Niveau niveau)
        {
            throw new NotImplementedException();
        }
    }
}