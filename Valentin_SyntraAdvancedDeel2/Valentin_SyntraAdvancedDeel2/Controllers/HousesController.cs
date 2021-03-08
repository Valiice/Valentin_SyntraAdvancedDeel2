using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Services;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Db;
using Valentin_SyntraAdvancedDeel2.Models;
using AutoMapper;

namespace Valentin_SyntraAdvancedDeel2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public HousesController(IMapper mapper, IHouseService houseService)
        {
            _mapper = mapper;
            _houseService = houseService;
        }
        [HttpPost("Create-House")]
        public ActionResult<House> CreateNewHouse(CreateHouseDTO createHouse)
        {
            var houseMapper = _mapper.Map<House>(createHouse);
            _houseService.CreateHouse(houseMapper);
            return Ok(houseMapper);
        }
        [HttpGet("Get-All-Houses")]
        public ActionResult<List<ResponseHouseWithPersonsDTO>> GetAllHouses()
        {
            var houses = _houseService.GetAllHouses();
            var listOfResponseHouseDTO = _mapper.Map<List<ResponseHouseWithPersonsDTO>>(houses);
            return Ok(listOfResponseHouseDTO);
        }
        [HttpGet("Get-One-House")]
        public ActionResult<ResponseHouseWithPersonsDTO> GetHouse(int Id)
        {
            var house = _houseService.GetHouse(Id);
            var ResponseHouseDTO = _mapper.Map<ResponseHouseWithPersonsDTO>(house);
            return Ok(ResponseHouseDTO);
        }
        [HttpPut("Update-House")]
        public ActionResult<ResponseHouseWithPersonsDTO> UpdateHouse(int IdHouseToChange, CreateHouseDTO updateHouse)
        {
            var house = _houseService.UpdateHouseById(IdHouseToChange, updateHouse);
            var ResponseHouseDTO = _mapper.Map<ResponseHouseWithPersonsDTO>(house);
            return Ok(ResponseHouseDTO);
        }
        [HttpDelete("Delete-House")]
        public ActionResult DeleteHouseById(int IdHouseToDelete)
        {
            _houseService.DeleteHouseById(IdHouseToDelete);
            return Ok();
        }
        [HttpGet("Get-House-By-Postal")]
        public ActionResult<List<ResponseHouseWithPersonsDTO>> GetHouseByPostal(string postal)
        {
            var houses = _houseService.GetAllHousesByPostal(postal);
            var ListOfResponseHouseDTO = _mapper.Map<List<ResponseHouseWithPersonsDTO>>(houses);
            return Ok(ListOfResponseHouseDTO);
        }
    }
}
