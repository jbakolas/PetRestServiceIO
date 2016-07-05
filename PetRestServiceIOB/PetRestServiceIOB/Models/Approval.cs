using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetRestServiceIO.Models
{
    public class Approval
    {
        [Key]
        public int Id { set; get; }
        public bool Approved { set; get; }
        [JsonIgnore]
        public virtual Pet Pet { set; get; }
        [JsonIgnore]
        public virtual PetWalker PetWalker { set; get; }
    }
}