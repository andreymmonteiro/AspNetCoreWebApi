using AutoMapper;
using SmartSchool.API.Helper;
using SmartSchool.API.Models;
using SmartSchool.API.v1.Dtos;

namespace SmartSchool.API.v1.Profiles
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

        }
    }
}
