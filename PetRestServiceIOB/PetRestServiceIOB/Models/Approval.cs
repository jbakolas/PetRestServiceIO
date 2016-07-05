using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PetRestServiceIOB.Models
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
        [JsonIgnore]
        public virtual Owner Owner { set; get; }
    }
}