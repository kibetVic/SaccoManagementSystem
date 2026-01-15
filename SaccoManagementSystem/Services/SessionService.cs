using SaccoManagementSystem.Constants;
using SaccoManagementSystem.Models;

namespace SaccoManagementSystem.Services
{
   
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            
            _httpContextAccessor = httpContextAccessor;

        }
        public void SetUserSession(SystemUsers user, Client company)
        {
            var context = _httpContextAccessor.HttpContext;
            if (context == null) throw new InvalidOperationException("HttpContext is null.");

            var session = context.Session;

            // 1. CLEAR ALL SESSION DATA
            session.Clear();

            session.SetString(StrValues.LoggedInUser, user.UserName??"");
            session.SetString(StrValues.UserSacco, user.OrganizationCode??"");
            session.SetString(StrValues.UserGroup, user.UserGroup??"");
            session.SetString(StrValues.Branch, user.Branch ?? "");
            
        }
        // Optional: Just clear
        public void ClearSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.Clear();
        }
        // ✅ Add these helpers to retrieve data anywhere in the app
        public string? LoggedInUser => _httpContextAccessor.HttpContext?.Session.GetString(StrValues.LoggedInUser);
        public string? UserSacco => _httpContextAccessor.HttpContext?.Session.GetString(StrValues.UserSacco);
        public string? UserGroup => _httpContextAccessor.HttpContext?.Session.GetString(StrValues.UserGroup);
        public string? Branch => _httpContextAccessor.HttpContext?.Session.GetString(StrValues.Branch);
    }
}
