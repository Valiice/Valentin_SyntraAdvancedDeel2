using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Services;
using AutoMapper;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper, IPersonService personService)
        {
            _mapper = mapper;
            _personService = personService;
        }
        [HttpPost("Create Account")]
        public ActionResult<CreatePersonDTO> CreateNewAccount(CreatePersonDTO createAccount)
        {
            var createPersonDTO = _mapper.Map<Person>(createAccount);
            var newAccount = _personService.AddPerson(createPersonDTO);
            return Ok(newAccount);
        }
        [HttpGet("Login")]
        public ActionResult<string> LoginIntoAccount(string email, string password)
        {
            var loginTry = _personService.LoginPerson(email, password);
            return Ok(loginTry);
        }
        [HttpPut("Add-Person-To-House")]
        public ActionResult AddPersonToHouse(int idPerson, int idHouse)
        {
            var addPersonToHouse = _personService.AddPersonToHouse(idPerson, idHouse);
            return Ok();
        }
        [HttpPut("Change-Password")]
        public ActionResult<ResponsePersonDTO> ChangePasswordAccount(string email, string oldPassword, string newPassword)
        {
            var changePass = _personService.ChangePasswordPerson(email, oldPassword, newPassword);
            if (changePass)
                return Ok();
            else
                return Unauthorized();
        }
        [HttpDelete("Delete-Account")]
        public ActionResult<ResponsePersonDTO> DeleteAccount(string email, string password)
        {
            var deleteAccount = _personService.DeletePerson(email, password);
            if (deleteAccount)
                return Ok();
            else
                return Unauthorized();
        }
        [HttpGet("Get All Persons With Pet")]
        public ActionResult<List<ResponsePersonWithPetDTO>> GetAllAccountsWithPets()
        {
            var pets = _personService.GetPersonsWithPets();
            var listOfResponsePersonDTO = _mapper.Map<List<ResponsePersonWithPetDTO>>(pets);
            return Ok(listOfResponsePersonDTO);
        }
        [HttpGet("Get My Pets")]
        public ActionResult<List<ResponsePersonWithPetDTO>> GetMyPetsWithPerson(int userId)
        {
            var person = _personService.GetPersonWithPets(userId);
            var listOfResponsePersonDTO = _mapper.Map<ResponsePersonWithPetDTO>(person);
            return Ok(listOfResponsePersonDTO);
        }
    }
}
