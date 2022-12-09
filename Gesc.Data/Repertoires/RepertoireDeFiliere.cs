using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeFiliere : RepertoireGenerique<Filiere>, IRepertoireDeFiliere
    {
        public RepertoireDeFiliere(SchoolConfigDbContext context) : base(context)
        { }
    }
}
