using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PetRestServiceIOB.Models
{
    public class Pet
    {
        [Key]
        public int petId { get; set; }
        [Required]
        public String name { get; set; }

        public DateTime BirthDate { get; set; }

        //Navigation property 
        [JsonIgnore]
        public virtual Owner Owner { get; set; }

       /* public int CalculateAge(DateTime bTime)
        {
            DateTime petBirthDate = bTime;
            DateTime currentDate = DateTime.Today;
            TimeSpan span = currentDate.Subtract(petBirthDate);
            int years = (int)span.TotalDays/360;
            return years;
        }*/
    }
}