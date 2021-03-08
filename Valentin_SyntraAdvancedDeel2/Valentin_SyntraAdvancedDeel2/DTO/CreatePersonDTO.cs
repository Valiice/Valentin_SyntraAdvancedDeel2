using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_SyntraAdvancedDeel2.DTO
{
    public class CreatePersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
//#nullable enable
//        public int? HouseId { get; set; }
//#nullable disable
    }
}
