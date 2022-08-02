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
    public class OperationManager : GenericManager<FileOperation>, IOperationService
    {
        IOperationDal _operationDal;
        public OperationManager(IGenericDal<FileOperation> genericDal) : base(genericDal)
        {
            _operationDal = (IOperationDal)genericDal;
        }

        public List<FileOperation> GetListWithAdmin(int id)
        {
            return _operationDal.GetListWithAdmin(id);
        }

      

        public List<FileOperation> GetListWithSender(int id)
        {
            return _operationDal.GetListWithSender(id);
        }
    }
}
