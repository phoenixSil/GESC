using AutoMapper;
using Gesc.Features.Contrats.Repertoires;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.Features.Core.BaseFactoryClass
{
    public abstract class BaseCommandHandler<T> : IRequestHandler<T, ReponseDeRequette>
        where T : BaseCommand
    {
        protected readonly IPointDaccess _pointDaccess;
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public BaseCommandHandler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }

        public abstract Task<ReponseDeRequette> Handle(T request, CancellationToken cancellationToken);
    }
}
