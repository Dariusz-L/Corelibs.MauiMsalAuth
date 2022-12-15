using System.IdentityModel.Tokens.Jwt;

namespace Common.Infrastructure.MauiMsalAuth
{
    public interface ISignInManager
    {
        Task SignIn();
        Task SignOut();
        Task<JwtSecurityToken> GetAccessToken();

        Task<bool> IsSignedIn();

        event Action<bool> OnAuthenticatedStateChanged;
    }
}
