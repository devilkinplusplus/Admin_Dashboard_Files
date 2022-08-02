using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AdminDashboardForTask.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager admin = new AdminManager(new EfAdminRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin user)
        {
            Context c = new Context();
            var datavalue = c.Admins.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (datavalue != null && user.Password == user.ConfirmPassword)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,user.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                
                //For admin id
                HttpContext.Session.SetString("username",JsonConvert.SerializeObject(datavalue));

                //Admin Login Time
                datavalue.DateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                admin.TUpdate(datavalue);
                return RedirectToAction("Index", "Dashboard");
            }else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


    }
}
