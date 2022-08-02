using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminDashboardForTask.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin user)
        {
            AdminValidator validations = new AdminValidator();
            ValidationResult results = validations.Validate(user);
            if (results.IsValid)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    adminManager.TAdd(user);
                    return RedirectToAction("Index","Login");
                }
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

    }
}
