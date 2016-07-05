using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetRestServiceIO.Models
{
    public class Owner
    {
        [Key]
        public int ownerId { set; get; }
        [Required]
        public String firstName { set; get; }
        [Required]
        public String lastName { set; get; }
        [Required]
        public String email { set; get; }

        public virtual List<Pet> Pets { get; set; }
    }
}