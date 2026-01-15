using SaccoManagementSystem.Models.DB;
using Microsoft.AspNetCore.Http;
using SaccoManagementSystem.Constants;
using SaccoManagementSystem.Models.DB;

namespace SaccoManagementSystem.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationDBContext _db;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        protected string GetClientCode()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return httpContext?.Session.GetString(StrValues.UserSacco) ?? "";
        }

        protected string GetLoggedInUser()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return httpContext?.Session.GetString(StrValues.LoggedInUser) ?? "";
        }

        protected string GetUserBranch()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            return httpContext?.Session.GetString(StrValues.Branch) ?? "";
        }
    }
}