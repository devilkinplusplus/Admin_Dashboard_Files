using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AdminDashboardForTask.Controllers
{
    public class MailController : Controller
    {
        OperationManager om = new OperationManager(new EfOperationRepository());
        DownloadManager dm = new DownloadManager(new EfDownloadRepository());
        Context c = new Context();
        public IActionResult Inbox(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            id = sessionUser.AdminID;
            var values = om.GetListWithAdmin(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMail()
        {
            CategoryValues();
            AdminValues();
            return View();
        }

        [HttpPost]
        public IActionResult CreateMail(FileOperation mail)
        {
            MailValidator validations = new MailValidator();
            ValidationResult result = validations.Validate(mail);
            if (result.IsValid)
            {
                var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
                mail.SenderID = sessionUser.AdminID;
                mail.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                om.TAdd(mail);
                return RedirectToAction("Sent");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        private void CategoryValues()
        {
            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            List<SelectListItem> values = (from x in c.Categories.ToList().Where(x => x.AdminID == sessionUser.AdminID)
                                           select new SelectListItem
                                           {
                                               Text = x.FileName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.val = values;
        }

        private void AdminValues()
        {
            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            List<SelectListItem> values = (from x in c.Admins.ToList()
                                           where x.AdminID != sessionUser.AdminID
                                           select new SelectListItem
                                           {
                                               Text = x.Email,
                                               Value = x.AdminID.ToString()
                                           }).ToList();
            ViewBag.adm = values;

        }

        public IActionResult Sent(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            id = sessionUser.AdminID;
            var values = om.GetListWithSender(id);
            return View(values);
        }

        public IActionResult DownloadMail(int id, DownloadOperation operation)
        {
            operation.DownloadFileStatus = true;
            operation.DownloadDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            operation.ReceiverID = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username")).AdminID;
            operation.CategoryID = id;
            dm.TAdd(operation);
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult CategoryStatus(int id)
        {
            var data = dm.GetWithCategories(id);
            if (data != null)
            {
                data.DownloadFileStatus = false;
                dm.TUpdate(data);
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
