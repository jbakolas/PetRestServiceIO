using System.Security.Principal;

namespace PetRestServiceIOB.Filters
{
    // Basic Authentication identity
    
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        
        // Get/Set for password
        
        public string Password { get; set; }
       
        // Get/Set for UserName
       
        public string UserName { get; set; }
        
        // Get/Set for UserId
        
        public int UserId { get; set; }

        
        // Basic Authentication Identity Constructor
        
        public BasicAuthenticationIdentity(string userName, string password)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }
}