using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Db;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Services
{
    public class PetService : IPetService
    {
        public Pet GetPet(int Id)
        {
            using (var db = new AccountDbContext())
            {
                var pet = db.Pets
                    .Include(x => x.Owner).ToList()
                    .FirstOrDefault(pet => pet.Id == Id);
                return pet;
            }
        }
        public List<Pet> GetPets()
        {
            using (var db = new AccountDbContext())
            {
                var pets = db.Pets
                    .Include(x => x.Owner)
                    .Include(x => x.PetType).ToList();
                return pets;
            }
        }

        public Pet CreatePet(Pet pet)
        {
            using (var db = new AccountDbContext())
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return pet;
            }
        }

        public void DeletePetById(int petIdToDelete)
        {
            using (var db = new AccountDbContext())
            {
                var pet = db.Pets.FirstOrDefault(pet => pet.Id == petIdToDelete);
                db.Pets.Remove(pet);
                db.SaveChanges();
            }
        }
        public Pet UpdatePetById(Pet petIdToEdit, CreatePetDTO newPetValues)
        {
            using (var db = new AccountDbContext())
            {
                var pet = db.Pets.FirstOrDefault(pet => pet.Id == petIdToEdit.Id);
                pet.Name = newPetValues.Name;
                pet.Birthdate = newPetValues.Birthdate;
                pet.PetTypeId = newPetValues.PetTypeId;
                pet.OwnerId = newPetValues.OwnerId;
                db.Pets.Update(pet);
                db.SaveChanges();
                return pet;
            }
        }

        public IEnumerable<Pet> GetAllPetsByType(string petTypeName)
        {
            using (var db = new AccountDbContext())
            {
                var pets = db.Pets
                    .Include(x => x.PetType).ToList()
                    .Where(pet => pet.PetType.PetTypeName == petTypeName);
                    //.FirstOrDefault(pet => pet.PetType.PetTypeName == petTypeName);
                return pets;
            }
        }


        public Pet ChangeOwner(int petId, int newOwnerId)
        {
            using (var db = new AccountDbContext())
            {
                var pet = db.Pets.FirstOrDefault(pet => pet.Id == petId);
                pet.OwnerId = newOwnerId;
                db.Pets.Update(pet);
                db.SaveChanges();
                return pet;
            }
        }
    }
}
