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
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IMapper mapper, IPetService petService)
        {
            _mapper = mapper;
            _petService = petService;
        }
        [HttpPost("Create-Pet")]
        public ActionResult<Pet> CreateNewPet(CreatePetDTO createPet)
        {
            var newPet = _mapper.Map<Pet>(createPet);
            _petService.CreatePet(newPet);
            return Ok(newPet);
        }
        [HttpGet("Get-All-Pets")]
        public ActionResult<List<ResponsePetWithOwnerDTO>> GetAllPets()
        {
            var pets = _petService.GetPets();
            var listOfResponsePetDTO = _mapper.Map<List<ResponsePetWithOwnerDTO>>(pets);
            return Ok(listOfResponsePetDTO);
        }
        [HttpGet("Get-One-Pet")]
        public ActionResult<ResponsePetWithOwnerDTO> GetPet(int Id)
        {
            var pet = _petService.GetPet(Id);
            var responsePetDTO = _mapper.Map<ResponsePetWithOwnerDTO>(pet);
            return Ok(responsePetDTO);
        }
        [HttpPut("Update-Pet")]
        public ActionResult<CreatePetDTO> UpdatePetById(int petIdToEdit, CreatePetDTO newPetValues)
        {
            var getPet = _petService.GetPet(petIdToEdit);
            var changePet = _mapper.Map<Pet>(getPet);
            var updatePet = _petService.UpdatePetById(changePet, newPetValues);
            return Ok(updatePet);
        }
        [HttpDelete("Delete-Pet")]
        public ActionResult DeletePetById(int Id)
        {
            _petService.DeletePetById(Id);
            return Ok();
        }
        [HttpPut("Change-Owner-Pet")]
        public ActionResult ChangePetOwner(int petId, int newOwnerId)
        {
            var petChangeOwner = _petService.ChangeOwner(petId, newOwnerId);
            return Ok(petChangeOwner);
        }
        [HttpGet("Get-All-Pets-By-Type")]
        public ActionResult<List<ResponsePetWithoutTypeDTO>> GetAllPetsByType(string petType)
        {
            var petsToSearch = _petService.GetAllPetsByType(petType);
            var mapperChange = _mapper.Map<List<ResponsePetWithoutTypeDTO>>(petsToSearch);
            return Ok(mapperChange);
        }
    }
}
