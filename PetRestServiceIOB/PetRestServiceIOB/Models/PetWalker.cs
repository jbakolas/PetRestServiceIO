using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetRestServiceIOB.Models
{
    public class PetWalker
    {
        [Key]
        public int walkerId { set; get; }
        [Required]
        public String firstName { set; get; }
        [Required]
        public String lastName { set; get; }
        [Required]
        public String email { set; get; }

        public String phone { set; get; }

        //Navigation property - one to many
        //public ICollection<Pet> Pets { get; set; }
        public virtual List<Approval> Approvals { set; get; }
    }
}