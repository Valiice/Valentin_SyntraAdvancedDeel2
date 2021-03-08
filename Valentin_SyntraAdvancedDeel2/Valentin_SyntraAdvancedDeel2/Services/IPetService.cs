using System.Collections.Generic;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Services
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        List<Pet> GetPets();
        Pet GetPet(int Id);
        Pet UpdatePetById(Pet petIdToEdit, CreatePetDTO newPetValues);
        void DeletePetById(int petIdToDelete);
        Pet ChangeOwner(int petId, int newOwnerId);
        IEnumerable<Pet> GetAllPetsByType(string petTypeName);
    }
}