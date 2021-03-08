using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Db;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Services
{
    public class PersonService : IPersonService
    {
        public Person AddPerson(Person person)
        {
            using (var db = new AccountDbContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return person;
            }
        }

        public string LoginPerson(string email, string password)
        {
            using (var db = new AccountDbContext())
            {
                //Person emailPerson;
                var emailPerson = db.Persons.FirstOrDefault(person => person.Email == email);
                if (emailPerson == null || emailPerson.Password != password)
                {
                    return "false";
                }
                else
                    return "true";
            }
        }

        public bool DeletePerson(string email, string password)
        {
            using (var db = new AccountDbContext())
            {
                var personAccount = db.Persons.FirstOrDefault(person => person.Email == email);
                if (personAccount == null || personAccount.Password != password)
                {
                    return false;
                }
                else
                {
                    db.Persons.Remove(personAccount);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool ChangePasswordPerson(string email, string oldPassword, string newPassword)
        {
            using (var db = new AccountDbContext())
            {
                var personAccount = db.Persons.FirstOrDefault(person => person.Email == email);
                if (personAccount == null || personAccount.Password != oldPassword)
                {
                    return false;
                }
                else
                {
                    personAccount.Password = newPassword;
                    db.SaveChanges();
                    return true;
                }
                    
            }
        }


        public List<Person> GetPersonsWithPets()
        {
            using (var db = new AccountDbContext())
            {
                var listOfPersons = db.Persons.Include(x => x.Pets).ToList();
                return listOfPersons;
            }
        }

        public List<Person> GetPersons()
        {
            using (var db = new AccountDbContext())
            {
                return db.Persons.ToList();
            }
        }

        public Person GetPersonWithPets(int Id)
        {
            using (var db = new AccountDbContext())
            {
                var person = db.Persons
                    .Include(x => x.Pets).ToList()
                    .FirstOrDefault(person => person.Id == Id);
                return person;
            }
        }

        public Person AddPersonToHouse(int idPerson, int idHouse)
        {
            using (var db = new AccountDbContext())
            {
                var person = db.Persons
                    .Include(x => x.House).ToList()
                    .FirstOrDefault(person => person.Id == idPerson);
                person.HouseId = idHouse;
                db.Persons.Update(person);
                db.SaveChanges();
                return person;
            }
        }
    }
}
