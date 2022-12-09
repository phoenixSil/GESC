using Gesc.Domain.Modeles.Config;

namespace Gesc.Api.Dtos.Config.Departements
{
    public interface IDepartementDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }

    }
}
