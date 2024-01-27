using Microsoft.AspNetCore.Components.Authorization;
using SalesManager.Web.Interfaces;
using System.Security.Claims;

namespace SalesManager.Web.Authentication
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync() => await Program.GetAuthenticationState();

        public async Task UserLoginAsync(string authUser)
        {
            #region Update
            string[] userData = authUser.Split('|');
            string nameUser = userData[0];
            int idUser = int.Parse(userData[1]);

            List<Claim> claimsIdentity = new List<Claim>()
            {
                new Claim("IdUser", idUser.ToString()),
                new Claim(ClaimTypes.Name, nameUser)
            };

            ClaimsIdentity user = new ClaimsIdentity(claimsIdentity, "Authenticated");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(user);

            Program.SetAuthenticationState(claimsPrincipal);
            Program.SetIdUser(idUser);

            AuthenticationState authenticationState = await Program.GetAuthenticationState();
            #endregion Update

            NotifyAuthenticationStateChanged(Task.FromResult(authenticationState));
        }

        public void UserLogoutAsync()
        {
            Program.SetAuthenticationState(null);
            NotifyAuthenticationStateChanged(Program.GetAuthenticationState());
        }
    }
}
