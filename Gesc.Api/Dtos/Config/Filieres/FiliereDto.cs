using Gesc.Api.Modeles.Config;

namespace Gesc.Api.Dtos.Config.Filieres
{
    public class FiliereDto : IFiliereDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
    }
}
