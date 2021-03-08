using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_SyntraAdvancedDeel2.DTO
{
    public class ResponseHouseDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
    }
}
