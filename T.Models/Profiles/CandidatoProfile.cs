using AutoMapper;
using T.Models.DTOs;
using T.Models.Models;

namespace T.Models.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            /// <summary>   
            ///       Mapeo de Candidato a CandidatoDto
            /// </summary>    
            CreateMap<CandidatoDto, Candidato>().ReverseMap();
        }

    }
}
