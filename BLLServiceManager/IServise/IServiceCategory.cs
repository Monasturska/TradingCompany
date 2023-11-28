using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServiceManager.IServise
{
    public interface IServiceCategory
    {
        void AddObj(Category temp);
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        List<Category> GetProducts();
        Category GetObj(int id);
        Category ChangeValueObj(int id, string name);
        List<Category> GetCategoriesBlocked();
    }
}
