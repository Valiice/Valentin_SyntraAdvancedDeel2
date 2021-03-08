using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Profiles
{
    public class PetTypeProfile : Profile
    {
        public PetTypeProfile()
        {
            CreateMap<ResponsePetWithoutTypeDTO, PetType>().ReverseMap();
        }
    }
}
