using AutoMapper;
using SmartSchool.API.Models;
using SmartSchool.API.v2.Dtos;

namespace SmartSchool.API.v2.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            

            CreateMap<Professor, ProfessorDto>()
                .ForMember(destino => destino.Nome,
                options => options.MapFrom(resource => resource.Nome + " " + resource.Sobrenome));

            CreateMap<ProfessorDto, Professor>();

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
