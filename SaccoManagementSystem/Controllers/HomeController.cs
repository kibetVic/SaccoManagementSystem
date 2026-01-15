using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaccoManagementSystem.Constants;
using SaccoManagementSystem.Models;
using SaccoManagementSystem.Models.DB;
using SaccoManagementSystem.Models.Login;
using SaccoManagementSystem.Services;
using SaccoManagementSystem.Utils;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RentalManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _context;
        private readonly SessionService _sessionService;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext context, SessionService sessionService)
        {
            _logger = logger;
            _context = context;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVm login)
        {
            try
            {

                //GetInitialValues();
                if (string.IsNullOrEmpty(login.Username))
                {
                    ModelState.AddModelError("Username", "Kindly provide username");
                    return Json(new { success = false, message = "Kindly provide username" });
                }
                if (string.IsNullOrEmpty(login.Password))
                {
                    ModelState.AddModelError("Password", "Kindly provide password");
                    return Json(new { success = false, message = "Kindly provide password" });
                }
                var user = await _context.SystemUsers
                           .FirstOrDefaultAsync(u => u.UserName!.ToUpper().Equals(login.Username.ToUpper())
                           && u.Active);
                if (user == null)
                {
                    ModelState.AddModelError("Username", "Invalid User Name credentials");
                    return Json(new { success = false, message = "Invalid User Name credentials." });
                }
                var checksocietyifexist = await _context.Clients
                           .FirstOrDefaultAsync(u => u.CompanyCode!.ToUpper().Equals(user.OrganizationCode!.ToUpper()));
                if (checksocietyifexist == null)
                {
                    ModelState.AddModelError("CompanyNamecheck", "Invalid Society Name or Not Exist");
                    return Json(new { success = false, message = "Invalid Society Name or Not Exist." });
                }

                login.Password = Decryptor.Decript_String(login.Password);
                if (!user.Password!.Equals(login.Password))
                {
                    ModelState.AddModelError("Password", "Invalid User Password.");
                    return Json(new { success = false, message = "Invalid User Password." });
                }

                // ✅ Build Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName ?? ""),
                    new Claim("OrganizationCode", user.OrganizationCode ?? ""),
                    new Claim("UserGroup", user.UserGroup ?? ""),
                    new Claim("Branch", user.Branch ?? "")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(5)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                //_sessionService.SetUserSession(user, checksocietyifexist);

                return RedirectToAction(nameof(Index));

            }

            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View(login);
            }

        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: /Home/SignUp
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            var model = new SignUpViewModel();
            PopulateViewBags();
            return View(model);
        }

        // POST: /Home/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateViewBags();
                return View(model);
            }

            try
            {
                // Check if username already exists
                var existingUser = await _context.SystemUsers
                    .FirstOrDefaultAsync(u => u.UserName == model.UserName);

                if (existingUser != null)
                {
                    ModelState.AddModelError("UserName", "Username already exists. Please choose a different one.");
                    PopulateViewBags();
                    return View(model);
                }

                // Check if organization code exists (if needed)
                //var organization = await _context.Organizations
                //    .FirstOrDefaultAsync(o => o.Code == model.OrganizationCode);
                //if (organization == null)
                //{
                //    ModelState.AddModelError("OrganizationCode", "Invalid organization code.");
                //    PopulateViewBags();
                //    return View(model);
                //}

                // Hash the password
                var hashedPassword = HashPassword(model.Password);

                // Create new user
                var systemUser = new SystemUsers
                {
                    UserName = model.UserName,
                    Password = hashedPassword,
                    OrganizationCode = model.OrganizationCode,
                    UserGroup = model.UserGroup,
                    Branch = model.Branch,
                    Active = false // New users need to be activated by admin
                };

                _context.SystemUsers.Add(systemUser);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"New user registered: {model.UserName}");

                TempData["SuccessMessage"] = "Registration successful! Your account will be activated by an administrator soon.";
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user registration");
                ModelState.AddModelError("", "An error occurred during registration. Please try again.");
                PopulateViewBags();
                return View(model);
            }
        }

        // GET: /Home/Users - List all users (Admin only)
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await _context.SystemUsers
                .OrderBy(u => u.UserName)
                .ToListAsync();
            return View(users);
        }

        // GET: /Home/ActivateUser/{id} - Activate a user (Admin only)
        [HttpGet]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Active = true;
            _context.SystemUsers.Update(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"User {user.UserName} has been activated successfully.";
            return RedirectToAction("Users");
        }

        // GET: /Home/DeactivateUser/{id} - Deactivate a user (Admin only)
        [HttpGet]
        public async Task<IActionResult> DeactivateUser(int id)
        {
            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Active = false;
            _context.SystemUsers.Update(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"User {user.UserName} has been deactivated.";
            return RedirectToAction("Users");
        }

        // GET: /Home/DeleteUser/{id} - Delete a user (Admin only)
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.SystemUsers.Remove(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"User {user.UserName} has been deleted.";
            return RedirectToAction("Users");
        }

        // GET: /Home/EditUser/{id} - Edit user (Admin only)
        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _context.SystemUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            PopulateViewBags();
            return View(user);
        }

        // POST: /Home/EditUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(int id, SystemUsers model)
        {
            if (id != model.SystemUserId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                PopulateViewBags();
                return View(model);
            }

            try
            {
                var user = await _context.SystemUsers.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                // Update user properties
                user.UserName = model.UserName;
                user.OrganizationCode = model.OrganizationCode;
                user.UserGroup = model.UserGroup;
                user.Branch = model.Branch;
                user.Active = model.Active;

                // Only update password if provided
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.Password = HashPassword(model.Password);
                }

                _context.SystemUsers.Update(user);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "User updated successfully.";
                return RedirectToAction("Users");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                ModelState.AddModelError("", "An error occurred while updating the user.");
                PopulateViewBags();
                return View(model);
            }
        }

        private void PopulateViewBags()
        {
            // Populate User Groups dropdown
            ViewBag.UserGroups = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Administrator" },
                new SelectListItem { Value = "Manager", Text = "Manager" },
                new SelectListItem { Value = "Agent", Text = "Agent" },
                new SelectListItem { Value = "Accountant", Text = "Accountant" },
                new SelectListItem { Value = "Maintenance", Text = "Maintenance Staff" },
                new SelectListItem { Value = "Tenant", Text = "Tenant" }
            };

            // Populate Branches dropdown (you can load from database)
            ViewBag.Branches = new List<SelectListItem>
            {
                new SelectListItem { Value = "Main", Text = "Main Branch" },
                new SelectListItem { Value = "West", Text = "West Branch" },
                new SelectListItem { Value = "East", Text = "East Branch" },
                new SelectListItem { Value = "North", Text = "North Branch" },
                new SelectListItem { Value = "South", Text = "South Branch" }
            };
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}