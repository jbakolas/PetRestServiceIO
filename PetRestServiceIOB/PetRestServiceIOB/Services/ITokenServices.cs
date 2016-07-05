using PetRestServiceIOB.Entities;

namespace PetRestServiceIOB.Services
{
    public interface ITokenServices
    {
        TokenEntity GenerateToken(int userId);
        bool ValidateToken(string tokenId);
        bool Kill(string tokenId);
        bool DeleteByUserId(int userId);
     
    }
}
