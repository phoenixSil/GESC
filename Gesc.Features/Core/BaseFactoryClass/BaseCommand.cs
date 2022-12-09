using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.Features.Core.BaseFactoryClass
{
    public abstract class BaseCommand : IRequest<ReponseDeRequette>
    {
    }
}
