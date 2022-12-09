using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Ecoles.Validations;
using Gesc.Api.Features.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.Ecoles
{
    public class AjouterUneEcoleCmdHdler : IRequestHandler<AjouterUneEcoleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AjouterUneEcoleCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDecoleDto();
            var resultatValidation = await validateur.ValidateAsync(request.EcoleAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Ecole a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ecoleACreer = _mapper.Map<Ecole>(request.EcoleAAjouterDto);
                var result = await _pointDaccess.RepertoireDecole.Ajoutter(ecoleACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'une Ecole a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Ecole Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
