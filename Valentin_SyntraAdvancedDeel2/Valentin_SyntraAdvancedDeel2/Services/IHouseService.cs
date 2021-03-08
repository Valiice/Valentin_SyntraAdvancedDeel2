using System.Collections.Generic;
using Valentin_SyntraAdvancedDeel2.DTO;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.Services
{
    public interface IHouseService
    {
        House CreateHouse(House house);
        List<House> GetAllHouses();
        House GetHouse(int idHouse);
        House UpdateHouseById(int houseIdToEdit, CreateHouseDTO newHouseValues);
        void DeleteHouseById(int houseIdToDelete);
        IEnumerable<House> GetAllHousesByPostal(string postalCode);
    }
}