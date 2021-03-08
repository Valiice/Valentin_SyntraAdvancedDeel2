using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetDTO, Pet>().ReverseMap();
            CreateMap<ResponsePetDTO, Pet>().ReverseMap();
            CreateMap<ResponsePetWithoutTypeDTO, Pet>().ReverseMap();
            CreateMap<ResponsePetWithOwnerDTO, Pet>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner))
                .ReverseMap();
        }
    }
}
