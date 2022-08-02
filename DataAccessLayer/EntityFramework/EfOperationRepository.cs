using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfOperationRepository : GenericRepository<FileOperation>, IOperationDal
    {
        public List<FileOperation> GetListWithAdmin(int id)
        {
            using Context c = new Context();
            return c.FileOperations.Where(x => x.ReceiverID == id).Include(x => x.Category).Include(x=>x.SenderUser).ToList();
        }


        public List<FileOperation> GetListWithSender(int id)
        {
            using Context c = new Context();
            return c.FileOperations.Where(x => x.SenderID == id).Include(x=>x.Category).Include(x=>x.ReceiverUser).ToList();
        }
    }
}
