using Valentin_SyntraAdvancedDeel2.Models;
using System.Collections.Generic;

namespace Valentin_SyntraAdvancedDeel2.Services
{
    public interface IPersonService
    {
        Person AddPerson(Person person);
        string LoginPerson(string email, string password);
        bool ChangePasswordPerson(string email, string oldPassword, string newPassword);
        bool DeletePerson(string email, string password);
        Person AddPersonToHouse(int idPerson, int idHouse);
        List<Person> GetPersonsWithPets();
        List<Person> GetPersons();
        Person GetPersonWithPets(int Id);
    }
}