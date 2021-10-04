using AutoMapper;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;

namespace SmartSchool.API.Helper
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(destino => destino.Idade,
                        opt => opt.MapFrom(resource => resource.DataNasc.GetCurrentAge()))
                .ForMember(destino => destino.Nome,
                        opt => opt.MapFrom(resource => resource.Nome + " " + resource.Sobrenome))
                ;
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()
                .ForMember(destino => destino.Nome,
                options => options.MapFrom(resource => resource.Nome + " " + resource.Sobrenome));

            CreateMap<ProfessorDto, Professor>();

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
