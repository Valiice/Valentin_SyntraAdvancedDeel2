using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_SyntraAdvancedDeel2.DTO
{
    public class ResponsePetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
        public ResponsePetTypeDTO PetType { get; set; }
        public int OwnerId { get; set; }
    }
}
