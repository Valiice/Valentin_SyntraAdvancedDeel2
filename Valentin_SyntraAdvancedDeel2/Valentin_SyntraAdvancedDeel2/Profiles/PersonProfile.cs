using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<ResponsePersonDTO, Person>().ReverseMap();
            CreateMap<CreatePersonDTO, Person>().ReverseMap();
            CreateMap<ResponsePersonWithPetDTO, Person>()
                .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src.Pets))
                .ReverseMap();
        }
    }
}
