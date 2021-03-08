using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_SyntraAdvancedDeel2.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public List<Person> Persons { get; set; }
    }
}
