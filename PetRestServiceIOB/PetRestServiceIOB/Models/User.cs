using System.Collections.Generic;

namespace PetRestServiceIOB.Models
{
    public partial class User
    {
        public User()
        {
            this.Tokens = new HashSet<Token>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
