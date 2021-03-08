using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Profiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<CreateHouseDTO, House>().ReverseMap();
            CreateMap<ResponseHouseWithPersonsDTO, House>().ReverseMap();
        }
    }
}
