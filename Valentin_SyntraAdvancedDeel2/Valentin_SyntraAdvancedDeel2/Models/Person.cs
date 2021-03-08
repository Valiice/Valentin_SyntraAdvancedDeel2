using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Valentin_SyntraAdvancedDeel2.DTO;

namespace Valentin_SyntraAdvancedDeel2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
        public List<Pet> Pets { get; set; }
#nullable enable
        public int? HouseId { get; set; }
        public House? House { get; set; }
#nullable disable
    }
}
