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
    public class EfDownloadRepository : GenericRepository<DownloadOperation>, IDownloadDal
    {
        public List<DownloadOperation> GetListDownloadFiles(int id)
        {
            using Context c = new Context();
            return c.DownloadOperations.Where(x => x.ReceiverID == id).Include(x => x.Category).ToList();
        }

        public DownloadOperation GetWithCategories(int id)
        {
            using Context c = new Context();
            return c.DownloadOperations.Where(x=>x.CategoryID==id && x.DownloadFileStatus==true).FirstOrDefault();
        }
    }
}
