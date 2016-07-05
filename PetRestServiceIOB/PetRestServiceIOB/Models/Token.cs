﻿

namespace PetRestServiceIOB.Models
{
    public partial class Token
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public System.DateTime IssuedOn { get; set; }
        public System.DateTime ExpiresOn { get; set; }
    
        public virtual User User { get; set; }
    }
}
