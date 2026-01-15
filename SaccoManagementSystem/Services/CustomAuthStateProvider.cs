using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SaccoManagementSystem.Services
{
    
        public class CustomAuthStateProvider : AuthenticationStateProvider
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CustomAuthStateProvider(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public override Task<AuthenticationState> GetAuthenticationStateAsync()
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext == null || httpContext.User == null)
                {
                    var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                    return Task.FromResult(new AuthenticationState(anonymous));
                }

                return Task.FromResult(new AuthenticationState(httpContext.User));
            }

            public async Task LogoutAsync()
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }

                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(
                    new ClaimsPrincipal(new ClaimsIdentity())
                )));
            }
        }
    
}
