using BusinessLayer.Concreate;
using BusinessLayer.Validations;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace AdminDashboardForTask.Controllers
{

    public class DashboardController : Controller
    {
        CategoryManager categories = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            id = sessionUser.AdminID;
            var values = categories.GetListWithAdmin(id);
            return View(values);
        }


        [HttpGet]
        public IActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFile(Category2 p)
        {
            Category c = new Category();
            CategoryValidator validations = new CategoryValidator();
            ValidationResult results = validations.Validate(p);

            if (p.FileURL != null)
            {
                var extension = Path.GetExtension(p.FileURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileImages", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.FileURL.CopyTo(stream);
                c.FileURL = newimagename;
            }

            var sessionUser = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("username"));
            p.AdminID = sessionUser.AdminID;
            c.AdminID = p.AdminID;
            c.FileName = p.FileName;
            p.Status = true;
            c.Status = p.Status;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Date = p.Date;
            if (results.IsValid)
            {
                categories.TAdd(c);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public IActionResult DeleteFile(int id)
        {
            var data = categories.TGetById(id);
            categories.TDelete(data);
            return RedirectToAction("Index");
        }

        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            try
            {
                if (System.IO.File.Exists(path))
                {
                    var net = new System.Net.WebClient();
                    var data = net.DownloadData(path);
                    var content = new System.IO.MemoryStream(data);
                    memory = content;
                }
                memory.Position = 0;
            }
            catch (Exception)
            {
                memory.Close();
            }
            return memory;
        }


        public IActionResult DownloadFile(int id)
        {
            var data = categories.TGetById(id);
            var contentType = "APPLICATION/octet-stream";
            var memory = DownloadSinghFile(data.FileURL, @"wwwroot\FileImages");
            return File(memory.ToArray(), contentType, data.FileURL);
        }

    }
}
