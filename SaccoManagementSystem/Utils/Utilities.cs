using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaccoManagementSystem.Constants;
using SaccoManagementSystem.Models.DB;

namespace HospitalManagementSystem.Utils
    {
    public class Utilities
    {
        private  ApplicationDBContext _context;
        
        public Utilities(ApplicationDBContext context)
        {
              _context = context;
        }
        public void SetUpPrivileges(Controller controller)
        {
            var sacco = controller.HttpContext.Session.GetString(StrValues.UserSacco) ?? "";
            var Loggedinbranch = controller.HttpContext.Session.GetString(StrValues.Branch) ?? "";
            var loggedInUser = controller.HttpContext.Session.GetString(StrValues.LoggedInUser) ?? "";
           
       

            //controller.ViewBag.CompPhone = StrValues.CompPhone == company.PhoneNo ?? 0;
            controller.ViewBag.isProject = false;
            controller.ViewBag.User = StrValues.LoggedInUser == loggedInUser;


            
        }
    }
}
