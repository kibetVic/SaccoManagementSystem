using SaccoManagementSystem.Models.DB;
using Microsoft.EntityFrameworkCore;
using SaccoManagementSystem.Constants;
using SaccoManagementSystem.Models;
using SaccoManagementSystem.Models.DB;
using SaccoManagementSystem.Models.Login;
using SaccoManagementSystem.Utils;

namespace SaccoManagementSystem.Services
{
    public class AuthService
    {
        private readonly ApplicationDBContext _context;
        private readonly SessionService _sessionService;
        public AuthService(ApplicationDBContext context, SessionService sessionService)
        {
            
            _context = context;
            _sessionService = sessionService;

        }
        public async Task<(bool status, string message)> Login(LoginVm login)
        {
            try
            {

                //GetInitialValues();
                if (string.IsNullOrEmpty(login.Username))
                {
                   
                    return (false, "Kindly provide username" );
                }
                if (string.IsNullOrEmpty(login.Password))
                {
                    
                    return (false, "Kindly provide password");
                }
                var user = await _context.SystemUsers
                           .FirstOrDefaultAsync(u => u.UserName!.ToUpper().Equals(login.Username.ToUpper())
                           && u.Active);
                if (user == null)
                {

                    return (false, "Invalid User Name credentials.");
                } 
                var checksocietyifexist = await _context.Clients
                           .FirstOrDefaultAsync(u => u.CompanyCode!.ToUpper().Equals(user.OrganizationCode!.ToUpper()));
                if (checksocietyifexist == null)
                {
                    
                    return (false, "Client Not Exist.");
                }



                login.Password = Decryptor.Decript_String(login.Password);
                if (!user.Password!.Equals(login.Password))
                {
                   
                    return (false, "Invalid User Password.");
                }


                _sessionService.SetUserSession(user, checksocietyifexist);

                return (true, "Login Successful");

            }

            catch (Exception ex)
            {
               

                return (false, ex.Message);
            }

        }
    }
}
