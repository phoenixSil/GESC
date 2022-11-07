using AutoMapper;
using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Dtos.Config.Departements;
using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Dtos.Config.FiliereCycles;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Modeles;

namespace Gesc.Api.MappingProfile
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
        }
    }
}
