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
    public class CategoryManager:GenericManager<Category>, ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _categoryDal = (ICategoryDal)genericDal;
        }

        public List<Category> GetCategoriesByWriter(int id)
        {
            return _categoryDal.GetListAll(x=>x.AdminID==id);
        }

        public List<Category> GetListWithAdmin(int id)
        {
            return _categoryDal.GetListWithAdmin(id);
        }

     
    }
}
