using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboardForTask.ViewComponents.Admin
{
    public class AdminTable:ViewComponent
    {
        AdminManager admin = new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            var values = admin.TGetList();
            return View(values);
        }
    }
}
