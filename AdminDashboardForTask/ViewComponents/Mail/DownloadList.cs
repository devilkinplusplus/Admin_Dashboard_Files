using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminDashboardForTask.ViewComponents.Mail
{
    public class DownloadList:ViewComponent
    {
        DownloadManager dm = new DownloadManager(new EfDownloadRepository());
        public IViewComponentResult Invoke(int id)
        {
            var sessionUser = JsonConvert.DeserializeObject<EntityLayer.Concreate.Admin>(HttpContext.Session.GetString("username"));
            id = sessionUser.AdminID;
            var values = dm.GetListDownloadFiles(id);
            return View(values);
        }
    }
}
