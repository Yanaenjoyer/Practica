using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Web.Auth


{
    public class CistomAuthenticationStateProvider:AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ProtectedLocalStorage _localStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CistomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, ProtectedLocalStorage localStorage)
        {
            _sessionStorage = sessionStorage;
            _localStorage = localStorage;   
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync ()
        {
            try
            {
               
                var userSessionStorageResult = await _localStorage.GetAsync<UserSession>("LocalUserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                CurrentUser.Id = userSessionStorageResult.Value.Id;
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Sid,userSession.Id),
                new Claim(ClaimTypes.Name,userSession.FirstName),
                new Claim(ClaimTypes.Email,userSession.Email),
                new Claim(ClaimTypes.Role,userSession.Role),
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                try
                {
                    var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                    var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                    if (userSession == null)
                    {
                        return await Task.FromResult(new AuthenticationState(_anonymous));
                    }
                    CurrentUser.Id = userSessionStorageResult.Value.Id;
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Sid,userSession.Id),
                    new Claim(ClaimTypes.Name,userSession.FirstName),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Role,userSession.Role),
                }, "CustomAuth"));

                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
                catch
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
            }
        }
        public async Task UpdateAuthenticationStateAsync ( UserSession userSession )
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await _localStorage.SetAsync("LocalUserSession", userSession);
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,userSession.Id),
                     new Claim(ClaimTypes.Name,userSession.FirstName),
                      new Claim(ClaimTypes.Email,userSession.Email),
                       new Claim(ClaimTypes.Role,userSession.Role)
                }));


            }
            else
            {

                await _localStorage.DeleteAsync("LocalUserSession");
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
    
}
