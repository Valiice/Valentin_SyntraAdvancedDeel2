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
    public class HouseService : IHouseService
    {
        public House CreateHouse(House house)
        {
            using (var db = new AccountDbContext())
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return house;
            }
        }
        public House GetHouse(int idHouse)
        {
            using (var db = new AccountDbContext())
            {
                var house = db.Houses
                    .Include(x => x.Persons)
                    .FirstOrDefault(x => x.Id == idHouse);
                return house;
            }
        }
        public List<House> GetAllHouses()
        {
            using (var db = new AccountDbContext())
            {
                var houses = db.Houses
                    .Include(x => x.Persons).ToList();
                return houses;
            }
        }

        public void DeleteHouseById(int houseIdToDelete)
        {
            using (var db = new AccountDbContext())
            {
                var house = db.Houses.FirstOrDefault(house => house.Id == houseIdToDelete);
                db.Houses.Remove(house);
                db.SaveChanges();
            }
        }


        public IEnumerable<House> GetAllHousesByPostal(string postalCode)
        {
            using (var db = new AccountDbContext())
            {
                var houses = db.Houses
                    .Include(x => x.Persons)
                    .Where(house => house.PostCode == postalCode).ToList();
                return houses;
            }
        }


        public House UpdateHouseById(int houseIdToEdit, CreateHouseDTO newHouseValues)
        {
            using (var db = new AccountDbContext())
            {
                var house = db.Houses.FirstOrDefault(house => house.Id == houseIdToEdit);
                house.Street = newHouseValues.Street;
                house.HouseNr = newHouseValues.HouseNr;
                house.PostCode = newHouseValues.PostCode;
                house.City = newHouseValues.City;
                db.Houses.Update(house);
                db.SaveChanges();
                return house;
            }
        }

    }
}
