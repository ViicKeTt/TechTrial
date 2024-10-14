using AutoMapper;
using T.Models.DTOs;
using T.Models.Models;

namespace T.Models.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            // Mapeo de Candidato a CandidatoDto
            CreateMap<CandidatoDto, Candidato>().ReverseMap();
        }

    }
}
