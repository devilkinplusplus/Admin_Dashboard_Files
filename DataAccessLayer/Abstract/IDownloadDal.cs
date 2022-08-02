using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDownloadDal:IGenericDal<DownloadOperation>
    {
        List<DownloadOperation> GetListDownloadFiles(int id);
        DownloadOperation GetWithCategories(int id);
    }
}
