using System.Threading;
using System.Web.Http.Controllers;
using BusinessServices;

namespace PetRestServiceIOB.Filters
{
    // Custom Authentication Filter Extending basic Authentication
    
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        // Default Authentication Constructor
        public ApiAuthenticationFilter()
        {
        }

        // AuthenticationFilter constructor with isActive parameter
        
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        // Protected overriden method for authorizing user
       
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserServices)) as IUserServices;
            if (provider != null)
            {
                var userId = provider.Authenticate(username, password);
                if (userId>0)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.UserId = userId;
                    return true;
                }
            }
            return false;
        }
    }
}