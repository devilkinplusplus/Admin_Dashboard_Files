using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        List<Category> GetCategoriesByWriter(int id);
        List<Category> GetListWithAdmin(int id);
    }
}
