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
    public class DownloadManager : GenericManager<DownloadOperation>, IDownloadService
    {
        IDownloadDal _downloadDal;
        public DownloadManager(IGenericDal<DownloadOperation> genericDal) : base(genericDal)
        {
            _downloadDal = (IDownloadDal)genericDal;
        }

        public List<DownloadOperation> GetListDownloadFiles(int id)
        {
            return _downloadDal.GetListDownloadFiles(id);
        }

        public DownloadOperation GetWithCategories(int id)
        {
            return _downloadDal.GetWithCategories(id);
        }
    }
}
