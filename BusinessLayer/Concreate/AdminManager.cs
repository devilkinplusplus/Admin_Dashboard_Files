using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AdminManager : GenericManager<Admin>, IAdminService
    {
        public AdminManager(IGenericDal<Admin> genericDal) : base(genericDal)
        {
        }
    }
}
