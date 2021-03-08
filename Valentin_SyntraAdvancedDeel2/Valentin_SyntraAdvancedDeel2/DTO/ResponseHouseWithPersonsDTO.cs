using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.Models;

namespace Valentin_SyntraAdvancedDeel2.DTO
{
    public class ResponseHouseWithPersonsDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<ResponsePersonDTO> Persons { get; set; }
    }
}
