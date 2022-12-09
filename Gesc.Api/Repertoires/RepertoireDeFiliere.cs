using Gesc.Domain.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using MsCommun.Repertoires;

namespace Gesc.Api.Repertoires
{
    public class RepertoireDeFiliere : RepertoireGenerique<Filiere>, IRepertoireDeFiliere
    {
        public RepertoireDeFiliere(SchoolConfigDbContext context) : base(context)
        { }
    }
}
