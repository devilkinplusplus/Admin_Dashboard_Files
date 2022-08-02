using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOperationDal:IGenericDal<FileOperation>
    {
        List<FileOperation> GetListWithAdmin(int id);
        List<FileOperation> GetListWithSender(int id);
    }
}
