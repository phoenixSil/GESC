using AutoMapper;
using Gesc.Features.Dtos.Config.Cycles;
using Gesc.Features.Dtos.Config.Departements;
using Gesc.Features.Dtos.Config.Ecole;
using Gesc.Features.Dtos.Config.FiliereCycles;
using Gesc.Features.Dtos.Config.Filieres;
using Gesc.Features.Dtos.Config.Niveaux;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Domain.Modeles;
using MsCommun.Messages.Niveaux;

namespace Gesc.Features.MappingProfile
{
    public class MappingProf : Profile
    {
        public MappingProf()
        {

            CreateMap<Ecole, EcoleDto>().ReverseMap();
            CreateMap<Ecole, EcoleACreerDto>().ReverseMap();
            CreateMap<Ecole, EcoleDetailDto>().ReverseMap();
            CreateMap<Ecole, EcoleAModifierDto>().ReverseMap();

            CreateMap<Departement, DepartementDto>().ReverseMap();
            CreateMap<Departement, DepartementACreerDto>().ReverseMap();
            CreateMap<Departement, DepartementDetailDto>().ReverseMap();
            CreateMap<Departement, DepartementAModifierDto>().ReverseMap();

            CreateMap<Filiere, FiliereDto>().ReverseMap();
            CreateMap<Filiere, FiliereACreerDto>().ReverseMap();
            CreateMap<Filiere, FiliereDetailDto>().ReverseMap();
            CreateMap<Filiere, FiliereAModifierDto>().ReverseMap();

            CreateMap<Cycle, CycleDto>().ReverseMap();
            CreateMap<Cycle, CycleACreerDto>().ReverseMap();
            CreateMap<Cycle, CycleDetailDto>().ReverseMap();
            CreateMap<Cycle, CycleAModifierDto>().ReverseMap();

            CreateMap<FiliereCycle, FiliereCycleDto>().ReverseMap();
            CreateMap<FiliereCycle, FiliereCycleACreerDto>().ReverseMap();
            CreateMap<FiliereCycle, FiliereCycleDetailDto>().ReverseMap();
            CreateMap<FiliereCycle, FiliereCycleAModifierDto>().ReverseMap();

            CreateMap<Niveau, NiveauDto>().ReverseMap();
            CreateMap<Niveau, NiveauACreerDto>().ReverseMap();
            CreateMap<Niveau, NiveauDetailDto>().ReverseMap();
            CreateMap<Niveau, NiveauAModifierDto>().ReverseMap();
            CreateMap<NiveauACreerDto, NiveauAModifierDto>().ReverseMap();
            CreateMap<Niveau, AjouterNiveauMessage>()
                .ForMember(dest => dest.DesignationFiliere,
                            opt => opt.MapFrom(
                            src => src.FiliereCycle.Filiere.Designation))
                .ForMember(dest => dest.DesignationCycle,
                            opt => opt.MapFrom(
                            src => src.FiliereCycle.Cycle.Designation))
                .ForMember(dest => dest.NumeroExterne,
                            opt => opt.MapFrom(
                           src => src.Id));
        }
    }
}
