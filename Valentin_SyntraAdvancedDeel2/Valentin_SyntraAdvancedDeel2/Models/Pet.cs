using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Valentin_SyntraAdvancedDeel2.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }
        //public string PetType { get; set; }
        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Person Owner { get; set; }

    }
}
